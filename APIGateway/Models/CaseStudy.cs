using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Models
{
    public class CaseStudy
    {
        private readonly AgentHub _hub;
        public CaseStudy(AgentHub hub)
        {
            _hub = hub;
        }

        public async Task<ICollection<BankAgent>> AllBanks() =>
            await Task.Run(_hub.Banks);
        public async Task<ICollection<ShopAgent>> AllShops() =>
            await Task.Run(_hub.Shops);

        public async Task<Agent> Agent(string name) =>
            await Task.Run(() => _hub.GetAgent(name));

        public async Task<BankAgent> FastestBank(double price, Currency from, Currency to)
        {
            var banks = await AllBanks();
            var conversionTasks = banks
                .Select(async bank => (
                    bank,
                    await bank.Convert(price, from, to)));
            return await await Task.WhenAny(conversionTasks
                .Select(async bank => (await bank).bank));
        }

        public async Task<BankAgent> BestBank(double price, Currency from, Currency to)
        {
            var banks = await AllBanks();
            var conversionTasks = banks.Select(async bank => (bank, conversion: await bank.Convert(price, from, to)));
            return await await Task.WhenAll(conversionTasks)
                .ContinueWith(async task =>
                    (await task)
                    .OrderBy(c => c.conversion)
                    .Last()
                    .bank);
        }

        public async Task<double> CheapestConvert(double price, Currency from, Currency to) =>
            await await BestBank(100, from, to)
                .ContinueWith(async a => price / await (await a).Convert(1, from, to));

        public async Task<double> FastestConvert(double price, Currency from, Currency to) =>
            await await Task.WhenAny((await AllBanks())
                .Select(async bank => price / await bank.Convert(1, from, to)));

        public async Task<List<Task<ShopAgent>>> CheapestSellers(Item item, Currency currency)
        {
            return (await AllSellers(item))
                .Select(async shop => (shop, item: await shop.GetItemWithQuantity(item)))
                .OrderBy(async swi =>
                {
                    var (_, valueTuple) = await swi;
                    var product = valueTuple.Item1;
                    return product.Currency == currency
                        ? product.Price
                        : await CheapestConvert(product.Price, currency, product.Currency);
                })
                .Select(async s => (await s).shop)
                .ToList();
        }

        public async Task<List<ShopAgent>> AllSellers(Item item) =>
            (await Task.WhenAll(
                (await AllShops())
                .Select(async shop => (shop, items: await shop.GetItemsWithQuantity()))))
            .Where(swp => swp.items
                .Select(p => p.product.Type)
                .Contains(item))
            .Select(swp => swp.shop)
            .ToList();

        public async Task<Agent> CheapestSeller(Item item, Currency currency) =>
            await (await CheapestSellers(item, currency)).First();

        public async Task<Agent> FastestSeller(Item item)
        {
            var sellers = (await AllSellers(item))
                .Select(async shop => (shop, await shop.GetItemWithQuantity(item)));
            return await await Task.WhenAny(sellers)
                .ContinueWith(async sh => (await await sh).shop);
        }

        public async Task<double> PriceOf(Item item, Currency currency, int quantity)
        {
            double priceAccumulator = 0;
            var itemCounter = 0;
            var cheapShops = await CheapestSellers(item, currency);

            foreach (var shop in cheapShops)
            {
                var aShop = await shop;
                if (itemCounter == quantity) break;

                var itemWithQuantity = await aShop.GetItemWithQuantity(item);
                var itemsToAdd = itemCounter + itemWithQuantity.quantity <= quantity
                    ? itemWithQuantity.quantity
                    : quantity - itemCounter;
                itemCounter += itemsToAdd;
                priceAccumulator += itemsToAdd * (
                    currency == itemWithQuantity.product.Currency
                        ? itemWithQuantity.product.Price
                        : await CheapestConvert(itemWithQuantity.product.Price, currency, itemWithQuantity.product.Currency));
            }

            return priceAccumulator;
        }

        public async Task<double[,]> BankTable(string agent)
        {
            var agentInstance = _hub.GetAgent(agent);
            var bankAgent = (BankAgent)agentInstance;
            var tasks = new Task<double>[
                Enum.GetValues(typeof(Currency)).Length,
                Enum.GetValues(typeof(Currency)).Length];
            var doubles = new double[
                tasks.GetLength(0),
                tasks.GetLength(1)];
            foreach (var from in (Currency[])Enum.GetValues(typeof(Currency)))
            {
                foreach (var to in (Currency[])Enum.GetValues(typeof(Currency)))
                {
                    tasks[(int)from, (int)to] = bankAgent.Convert(1, from, to);
                }
            }

            for (int row = 0; row < tasks.GetLength(0); row++)
            {
                for (int col = 0; col < tasks.GetLength(1); col++)
                {
                    doubles[row, col] = await tasks[row, col];
                }
            }

            return doubles;
            
        }

        public async Task<List<(Product product, int quantity)>> Products(string agent)
        {
            var agentInstance = _hub.GetAgent(agent);
            var shopAgent = (ShopAgent)agentInstance;
            var items = (Item[]) Enum.GetValues(typeof(Item));
            var set = await shopAgent.GetItemsWithQuantity();
            return set.ToList();
    }
    }
}