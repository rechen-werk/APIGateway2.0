using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway2._0.Models
{
    public class ShopAgent : Agent
    {
        private static readonly Random Rand = new Random();
        private readonly HashSet<Item> _availableItems = new HashSet<Item>();
        private readonly Dictionary<Item, int> _itemCount = new Dictionary<Item, int>();

        public ShopAgent() {}
        public ShopAgent(string name, string description, params Item[] items) : base(name, description)
        {
            foreach (var item in items)
            {
                _availableItems.Add(item);
                _itemCount.Add(item, Rand.Next());
            }
        }

        public async Task<(Item, int)> GetItemWithQuantity(ItemType item)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next(0, 2)));
            return _itemCount
                .Where(itemWithCount => itemWithCount.Key.Type == item)
                .Select(itemWithCount => (itemWithCount.Key, itemWithCount.Value))
                .First();

        }

        public async Task<HashSet<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next(0, 2)));
            return _availableItems.Select(item => (item, _itemCount[item])).ToHashSet();
        }
        
        public async Task<HashSet<(Item, int)>> RequestItems(Dictionary<Item, int> request)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next(0, 10)));
            var items = new HashSet<(Item, int)>();  

            foreach (var key in request.Keys.Where(key => _availableItems.Contains(key) && _itemCount[key] >= request[key]))
            {
                _itemCount[key] -= request[key];
                items.Add((key, request[key]));
            }

            return items;
        }
    }
}