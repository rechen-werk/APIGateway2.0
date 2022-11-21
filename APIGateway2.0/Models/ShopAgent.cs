using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway2._0.Models
{
    public class ShopAgent : Agent
    {
        private static readonly Random Rand = new Random();
        private readonly Dictionary<ItemType, Item> _availableItems = new Dictionary<ItemType, Item>();
        private readonly Dictionary<ItemType, int> _itemCount = new Dictionary<ItemType, int>();

        public ShopAgent() {}
        public ShopAgent(string name, string description, params Item[] items) : base(name, description)
        {
            foreach (var item in items)
            {
                _availableItems.Add(item.Type, item);
                _itemCount.Add(item.Type, Rand.Next());
            }
        }

        public async Task<(Item, int)> GetItemWithQuantity(ItemType item)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next(0, 2)));
            return _availableItems
                .Where(itemTypeWithItem => itemTypeWithItem.Key == item)
                .Select(itemTypeWithItem => (itemTypeWithItem.Value, _itemCount[itemTypeWithItem.Key]))
                .First();

        }

        public async Task<HashSet<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next(0, 2)));
            return _availableItems.Select(item => (item.Value, _itemCount[item.Key])).ToHashSet();
        }
        
        /*public async Task<HashSet<(Item, int)>> RequestItems(Dictionary<ItemType, int> request)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next(0, 2)));
            var items = new HashSet<(Item, int)>();  


            foreach (var key in request.Keys.Where(key => _availableItems.Contains(key) && _itemCount[key] >= request[key]))
            {
                items.Add((_availableItems[key], request[key]));
            }

            return items;
        }*/
    }
}