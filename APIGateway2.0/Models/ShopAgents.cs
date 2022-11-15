using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models
{
    internal abstract class AbstractShop : IShopAgent{
        internal readonly Random Rand = new Random();
        public abstract Task<List<(Item, int)>> GetItemsWithQuantity();
    }
    
    
    
    
    internal class HoferAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }
    }
    
    internal class SparAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }
    }
    
    internal class LidlAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }
    }
    
    internal class BillaAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }
    }
    
    internal class ReweAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }
    }
    
    internal class KauflandAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }
    }
    
    internal class BillaPlusAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }
    }
    
    internal class PennyAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }
    }
    
    internal class NormaAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }
    }
}