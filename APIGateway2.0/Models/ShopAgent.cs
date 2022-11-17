using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway2._0.Models
{
    public class ShopAgent : Agent
    {
        public static readonly Random Rand = new Random();
        public HashSet<Item> AvailableItems = new HashSet<Item>();
        public Dictionary<Item, int> ItemCount = new Dictionary<Item, int>();

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
            //await Task.Delay(TimeSpan.FromSeconds(Rand.Next(0, 30)));
            return AvailableItems.Select(item => (item, ItemCount[item])).ToList();
        }
    }
}