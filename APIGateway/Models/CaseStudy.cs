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
            await _hub.Banks();
        public async Task<ICollection<ShopAgent>> AllShops() =>
            await _hub.Shops();

        public async Task<Agent> Agent(string name) =>
            await _hub.GetAgent(name);

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

    }
}