using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGateway.Models.Exceptions;

namespace APIGateway.Models
{
    public class AgentHub
    {
        private readonly Dictionary<string, BankAgent> _bankAgentList = new Dictionary<string, BankAgent>();
        private readonly Dictionary<string, ShopAgent> _shopAgentList = new Dictionary<string, ShopAgent>();
        public IList<ShopAgent> Shops => _shopAgentList.Values.ToList().AsReadOnly();
        public IList<BankAgent> Banks => _bankAgentList.Values.ToList().AsReadOnly();

        public Agent GetAgent(string name)
        {
            if (_bankAgentList.ContainsKey(name)) return _bankAgentList[name];
            if (_shopAgentList.ContainsKey(name)) return _shopAgentList[name];
            throw new NoSuchAgentException(name + " could not be found in " + nameof(AgentHub) + ".");
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

        public async Task<long> GetPriceAsync(List<(Item type, Currency currency, int amount)> request)
        {
            long priceAccumulator = 0;

            foreach (var item in request) priceAccumulator += await GetPriceAsync(request);

            return priceAccumulator;
        }

        public async Task<long> GetPriceAsync((Item type, Currency currency, int amount) request)
        {
            long priceAccumulator = 0;
            var itemCounter = 0;
            var cheapShops = await GetShopsSellingOrderedByPriceAscending(request.type, request.currency);

            foreach (var shop in cheapShops)
            {
                if (itemCounter == request.amount) break;

                var itemWithQuantity = await shop.GetItemWithQuantity(request.type);
                var bestBank = await GetBestExchangeRate(request.currency, itemWithQuantity.Item1.Currency);
                var itemsToAdd = itemCounter + itemWithQuantity.Item2 <= request.amount
                    ? itemWithQuantity.Item2
                    : request.amount - itemCounter;
                itemCounter += itemsToAdd;
                priceAccumulator += itemsToAdd * (
                    request.currency == itemWithQuantity.Item1.Currency
                        ? itemWithQuantity.Item1.Price
                        : await bestBank.Convert(itemWithQuantity.Item1.Price, request.currency,
                            itemWithQuantity.Item1.Currency));
            }

            return priceAccumulator;
        }

        public async Task<List<ShopAgent>> GetShopsSellingOrderedByPriceAscending(Item item, Currency currency)
        {
            return await Task.Run(async () =>
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
        }

        public async Task<ShopAgent> GetCheapestShopSelling(Item item, Currency currency)
        {
            return (await GetShopsSellingOrderedByPriceAscending(item, currency)).First();
        }

        public async Task<List<ShopAgent>> GetAllShopsSelling(Item item)
        {
            return await Task.Run(() =>
            {
                return Shops
                    .Where(shop => ShopContainsItem(shop).Result)
                    .ToList();

                async Task<bool> ShopContainsItem(ShopAgent shop)
                {
                    return (await shop.GetItemsWithQuantity())
                        .Select(shopItem => shopItem.Item1.Type)
                        .Contains(item);
                }
            });
        }

        public async Task<BankAgent> GetBestExchangeRate(Currency from, Currency to)
        {
            (BankAgent agent, long value) curMin = (null, long.MaxValue);
            foreach (var bankAgent in _bankAgentList.Select(async agentWithPrice => (agent: agentWithPrice.Value,
                         value: await agentWithPrice.Value.Convert(100, from, to))))
            {
                var bankWithPrice = await bankAgent;
                if (curMin.agent == null)
                {
                    curMin = (bankWithPrice.agent, bankWithPrice.value);
                    continue;
                }

                if (bankWithPrice.value > curMin.value) curMin = (bankWithPrice.agent, bankWithPrice.value);
            }

            return curMin.agent;
        }

        public async Task<BankAgent> GetFirstExchangeRate(Currency from, Currency to)
        {
            return (await await Task.WhenAny(
                _bankAgentList
                    .Select(async agent =>
                        (agent: agent.Value, value: await agent.Value.Convert(100, from, to)))
                    .ToArray())).agent;
        }
    }
}