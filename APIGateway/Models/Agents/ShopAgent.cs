using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Models
{
    public class ShopAgent : Agent
    {
        private static readonly Random Rand = new Random();
        private readonly Dictionary<Item, (Product, int)> _availableProducts = new Dictionary<Item, (Product, int)>();

        public ShopAgent()
        {
        }

        public ShopAgent(string name, string description, params (Product product, int quantity)[] items) : base(name,
            description)
        {
            foreach (var item in items) _availableProducts.Add(item.product.Type, item);
        }

        public async Task<(Product, int)> GetItemWithQuantity(Item item)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next(0, 2)));
            return _availableProducts
                .Where(itemTypeWithItem => itemTypeWithItem.Key == item)
                .Select(itemTypeWithItem => itemTypeWithItem.Value)
                .First();
        }

        public async Task<HashSet<(Product, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next(0, 2)));
            return _availableProducts
                .Select(item => item.Value)
                .ToHashSet();
        }
    }
}