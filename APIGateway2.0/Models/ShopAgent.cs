using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway2._0.Models
{
    public class ShopAgent : Agent
    {
        private static readonly Random Rand = new Random();
        private HashSet<Item> AvailableItems = new HashSet<Item>();
        private Dictionary<Item, int> ItemCount = new Dictionary<Item, int>();

        public ShopAgent() {}
        public ShopAgent(string name, string description, params Item[] items) : base(name, description)
        {
            foreach (var item in items)
            {
                AvailableItems.Add(item);
                ItemCount.Add(item, Rand.Next());
            }
        }

        public async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next(0, 10)));
            return AvailableItems.Select(item => (item, ItemCount[item])).ToList();
        }
    }
}