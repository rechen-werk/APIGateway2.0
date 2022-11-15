using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models
{
    internal abstract class AbstractShop : IShopAgent{
        internal readonly Random Rand = new Random();
        public abstract Task<List<(Item, int)>> GetItemsWithQuantity();
        public abstract string AsHtml();
    }
    
    
    
    
    internal class HoferAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }

        public override string AsHtml()
            => nameof(HoferAgent);
    }
    
    internal class SparAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }

        public override string AsHtml()
            => nameof(SparAgent);
    }
    
    internal class LidlAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }

        public override string AsHtml()
            => nameof(LidlAgent);
    }
    
    internal class BillaAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }

        public override string AsHtml()
            => nameof(BillaAgent);
    }
    
    internal class ReweAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }

        public override string AsHtml()
            => nameof(ReweAgent);
    }
    
    internal class KauflandAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }

        public override string AsHtml()
            => nameof(KauflandAgent);
    }
    
    internal class BillaPlusAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }

        public override string AsHtml()
            => nameof(BillaPlusAgent);
    }
    
    internal class PennyAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }

        public override string AsHtml()
            => nameof(PennyAgent);
    }
    
    internal class NormaAgent : AbstractShop{
        public override async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return new List<(Item, int)>();
        }
        public override string AsHtml()
            => nameof(NormaAgent);
    }
}