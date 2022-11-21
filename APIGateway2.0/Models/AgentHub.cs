using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace APIGateway2._0.Models
{
    public class AgentHub
    {
        private readonly Dictionary<string, ShopAgent> _shopAgentList = new Dictionary<string, ShopAgent>();
        private readonly Dictionary<string, BankAgent> _bankAgentList = new Dictionary<string, BankAgent>();

        public IList<ShopAgent> Shops =>
            _shopAgentList.Values.ToList().AsReadOnly();

        public IList<BankAgent> Banks =>
            _bankAgentList.Values.ToList().AsReadOnly();

        public AgentHub()
        {
            PseudoInit();
        }

        public Agent GetAgent(string name)
        {
            if (_bankAgentList.ContainsKey(name))
            {
                return _bankAgentList[name];
            }

            return _shopAgentList.ContainsKey(name) ? _shopAgentList[name] : null;
        }

        public void RegisterAgent(Agent agent)
        {
            switch (agent)
            {
                case BankAgent bankAgent:
                    _bankAgentList.Add(agent.Name, bankAgent);
                    break;
                case ShopAgent shopAgent:
                    _shopAgentList.Add(agent.Name, shopAgent);

                    break;
            }
        }

        public void UnregisterAgent(Agent agent)
        {
            switch (agent)
            {
                case BankAgent bankAgent:
                    _bankAgentList.Remove(bankAgent.Name);
                    break;
                case ShopAgent shopAgent:
                    _shopAgentList.Remove(shopAgent.Name);
                    break;
            }
        }

        private void PseudoInit()
        {
            RegisterAgent(
                new BankAgent(
                    "VeryExpensiveBank",
                    "Takes 50% of your money.",
                    async (price, from, to)
                        =>
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        return (long) (price * 0.5 * BankAgent.Table(from, to));
                    }
                )
            );

            RegisterAgent(
                new BankAgent(
                    "QuiteExpensiveBank",
                    "Takes 30% of your money.",
                    async (price, from, to)
                        =>
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        return (long) (price * 0.7 * BankAgent.Table(from, to));
                    }
                )
            );
            RegisterAgent(

                new BankAgent(
                    "ExpensiveBank",
                    "Takes 10% of your money.",
                    async (price, from, to)
                        => (long) (price * 0.9 * BankAgent.Table(from, to)))
            );
            RegisterAgent(
                new BankAgent(
                    "CheapBank",
                    "Takes 5% of your money.",
                    async (price, from, to)
                        =>
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        return (long) (price * 0.95 * BankAgent.Table(from, to));
                    }
                )
            );
            RegisterAgent(
                new BankAgent(
                    "FairBank",
                    "Takes none of your money.",
                    async (price, from, to)
                        =>
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        return (long) (price * BankAgent.Table(from, to));
                    }

                )
            );
            RegisterAgent(
                new BankAgent(
                    "UnresponsiveBank",
                    "Takes an hour to respond to each request.",
                    async (price, from, to)
                        =>
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        return (long) (price * BankAgent.Table(from, to));
                    })
            );
            RegisterAgent(
                new BankAgent(
                    "SlowCheapBank",
                    "Takes a second to respond to each request.",
                    async (price, from, to)
                        =>
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        return (long) (price * 0.95 * BankAgent.Table(from, to));
                    })
            );


            RegisterAgent(
                new ShopAgent(
                    "HoferAgent",
                    "Sells a few items.",
                    new Item(ItemType.Eggs, 3, Currency.USD),
                    new Item(ItemType.Butter, 3, Currency.USD),
                    new Item(ItemType.Bacon, 3, Currency.USD)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "SparAgent",
                    "Sells a few items.",
                    new Item(ItemType.Eggs, 2, Currency.EUR),
                    new Item(ItemType.Butter, 3, Currency.EUR),
                    new Item(ItemType.Bacon, 1, Currency.EUR),
                    new Item(ItemType.Apple, 3, Currency.EUR)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "LidlAgent",
                    "Sells a few items.",
                    new Item(ItemType.Banana, 3, Currency.JPY),
                    new Item(ItemType.Pear, 3, Currency.JPY),
                    new Item(ItemType.Grapes, 3, Currency.JPY),
                    new Item(ItemType.Avocado, 3, Currency.JPY)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "BillaAgent",
                    "Sells a few items.",
                    new Item(ItemType.Banana, 2, Currency.JPY),
                    new Item(ItemType.Pear, 4, Currency.JPY),
                    new Item(ItemType.Chocolate, 3, Currency.JPY),
                    new Item(ItemType.Cookies, 3, Currency.JPY)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "ReweAgent",
                    "Sells a few items.",
                    new Item(ItemType.Banana, 1, Currency.JPY),
                    new Item(ItemType.Rice, 3, Currency.JPY),
                    new Item(ItemType.Chocolate, 3, Currency.JPY),
                    new Item(ItemType.Cookies, 1, Currency.JPY),
                    new Item(ItemType.Fish, 2, Currency.JPY),
                    new Item(ItemType.Pear, 1, Currency.JPY)
                )
            );
            RegisterAgent(
                new ShopAgent(
                    "KauflandAgent",
                    "Sells a few items.",
                    new Item(ItemType.Oil, 1, Currency.JPY),
                    new Item(ItemType.Salt, 3, Currency.JPY),
                    new Item(ItemType.Pepper, 3, Currency.JPY),
                    new Item(ItemType.Ginger, 1, Currency.JPY)
                )
            );
            RegisterAgent(
                new ShopAgent(
                    "BillaPlusAgent",
                    "Sells a few items.",
                    new Item(ItemType.Oil, 2, Currency.JPY),
                    new Item(ItemType.Salt, 3, Currency.JPY),
                    new Item(ItemType.Pepper, 4, Currency.JPY),
                    new Item(ItemType.Ginger, 0, Currency.JPY),
                    new Item(ItemType.Mustard, 2, Currency.JPY),
                    new Item(ItemType.Ketchup, 2, Currency.JPY),
                    new Item(ItemType.Mayonnaise, 3, Currency.JPY)
                )
            );
            RegisterAgent(
                new ShopAgent(
                    "PennyAgent",
                    "Sells a few items.",
                    new Item(ItemType.Ketchup, 6, Currency.JPY),
                    new Item(ItemType.Mayonnaise, 6, Currency.JPY)
                )
            );
            RegisterAgent(
                new ShopAgent(
                    "NormaAgent",
                    "Sells a few items.",
                    new Item(ItemType.Banana, 4, Currency.JPY),
                    new Item(ItemType.Pear, 2, Currency.JPY),
                    new Item(ItemType.Chocolate, 3, Currency.JPY),
                    new Item(ItemType.Cookies, 1, Currency.JPY)
                )
            );
        }

        public async Task<long> GetPriceAsync(List<(ItemType type, Currency currency, int amount)> request)
        {
            long priceAccumulator = 0;

            foreach (var item in request)
            {
                priceAccumulator += await GetPriceAsync(request);
            }

            return priceAccumulator;
        }

        public async Task<long> GetPriceAsync((ItemType type, Currency currency, int amount) request)
        {
            long priceAccumulator = 0;
            var itemCounter = 0;
            var cheapShops = await GetShopsSellingOrderedByPriceAscending(request.type, request.currency);

            foreach (var shop in cheapShops)
            {
                if (itemCounter == request.amount)
                {
                    break;
                }

                var itemWithQuantity = await shop.GetItemWithQuantity(request.type);
                var bestBank = await GetBestExchangeRate(request.currency, itemWithQuantity.Item1.Currency);
                var itemsToAdd = itemCounter + itemWithQuantity.Item2 <= request.amount
                    ? itemWithQuantity.Item2
                    : request.amount - itemCounter;
                itemCounter += itemsToAdd;
                priceAccumulator += itemsToAdd * (
                    request.currency == itemWithQuantity.Item1.Currency
                        ? itemWithQuantity.Item1.Price
                        : await bestBank.Convert(itemWithQuantity.Item1.Price, request.currency, itemWithQuantity.Item1.Currency));

            }
            return priceAccumulator;
        }

        public async Task<List<ShopAgent>> GetShopsSellingOrderedByPriceAscending(ItemType item, Currency currency) =>
            await Task.Run(async () =>
                (await GetAllShopsSelling(item))
                .Select(async shop => (shop, shopItem: await shop.GetItemWithQuantity(item)))
                .Select(async shopWithItem =>
                {
                    var tuple = await shopWithItem;
                    var itemCurrency = tuple.shopItem.Item1.Currency;
                    var itemPrice = tuple.shopItem.Item1.Price;
                    return (tuple.shop, itemCurrency == currency
                        ? itemPrice
                        : await (await GetBestExchangeRate(currency, itemCurrency))
                            .Convert(itemPrice, currency, itemCurrency));
                })
                .OrderBy(async tuple => (await tuple).Item2)
                .Select(tuple => tuple.Result.shop)
                .ToList());

        public async Task<ShopAgent> GetCheapestShopSelling(ItemType item, Currency currency) =>
            (await GetShopsSellingOrderedByPriceAscending(item, currency)).First();

        public async Task<List<ShopAgent>> GetAllShopsSelling(ItemType item)
        {
            return await Task.Run(() =>
            {
                return Shops
                    .Where(shop => ShopContainsItem(shop).Result)
                    .ToList();

                async Task<bool> ShopContainsItem(ShopAgent shop) =>
                    (await shop.GetItemsWithQuantity())
                    .Select(shopItem => shopItem.Item1.Type)
                    .Contains(item);
            });
        }

        public async Task<BankAgent> GetBestExchangeRate(Currency from, Currency to)
        {
            (BankAgent agent, long value) curMin = (null, long.MaxValue);
            foreach (var bankAgent in _bankAgentList.Select(async agentWithPrice => (agent: agentWithPrice.Value, value: await agentWithPrice.Value.Convert(100, from, to))))
            {
                var bankWithPrice = await bankAgent;
                if (curMin.agent == null)
                {
                    curMin = (bankWithPrice.agent, bankWithPrice.value);
                    continue;
                }

                if (bankWithPrice.value > curMin.value)
                {
                    curMin = (bankWithPrice.agent, bankWithPrice.value);
                }
            }

            return curMin.agent;
        }
        public async Task<BankAgent> GetFirstExchangeRate(Currency from, Currency to) =>
            (await await Task.WhenAny(
                _bankAgentList
                    .Select(async agent =>
                        (agent: agent.Value, value: await agent.Value.Convert(100, from, to)))
                    .ToArray())).agent;
    }


}