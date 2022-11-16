using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    internal abstract class AbstractShop : IShopAgent{
        internal readonly Random Rand = new Random();
        internal readonly HashSet<Item> AvailableItems = new HashSet<Item>();
        private readonly Dictionary<Item, int> ItemCount = new Dictionary<Item, int>();
        //public abstract Task<List<(Item, int)>> GetItemsWithQuantity();
        public abstract string AsHtml();

        internal AbstractShop()
        {
            Init();
            GenerateItemCount();
        }

        protected abstract void Init();

        private void GenerateItemCount()
        {
            foreach (var item in AvailableItems)
            {
                ItemCount.Add(item, Rand.Next());
            }
        }
        
        public async Task<List<(Item, int)>> GetItemsWithQuantity()
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return AvailableItems.Select(item => (item, ItemCount[item])).ToList();
        }
    }


    internal class HoferAgent : AbstractShop{ 
        public override string AsHtml()
            => nameof(HoferAgent);

        protected override void Init()
        {
            var eggs = new Item(ItemType.Eggs, 3, Currency.USD);
            AvailableItems.Add(eggs);
            var butter = new Item(ItemType.Butter, 3, Currency.USD);
            AvailableItems.Add(butter);
            var bacon = new Item(ItemType.Bacon, 3, Currency.USD);
            AvailableItems.Add(bacon);
        }
    }
    
    internal class SparAgent : AbstractShop{ 
        public override string AsHtml()
            => nameof(SparAgent);

        protected override void Init()
        {
            var eggs = new Item(ItemType.Eggs, 2, Currency.EUR);
            AvailableItems.Add(eggs);
            var butter = new Item(ItemType.Butter, 3, Currency.EUR);
            AvailableItems.Add(butter);
            var bacon = new Item(ItemType.Bacon, 1, Currency.EUR);
            AvailableItems.Add(bacon);
            var apple = new Item(ItemType.Apple, 3, Currency.EUR);
            AvailableItems.Add(apple);
        }
    }
    
    internal class LidlAgent : AbstractShop{
        public override string AsHtml()
            => nameof(LidlAgent);

        protected override void Init()
        {
            var banana = new Item(ItemType.Banana, 3, Currency.JPY);
            AvailableItems.Add(banana);
            var pear = new Item(ItemType.Pear, 3, Currency.JPY);
            AvailableItems.Add(pear);
            var grapes = new Item(ItemType.Grapes, 3, Currency.JPY);
            AvailableItems.Add(grapes);
            var avocado = new Item(ItemType.Avocado, 3, Currency.JPY);
            AvailableItems.Add(avocado);
        }
    }
    
    internal class BillaAgent : AbstractShop{
        public override string AsHtml()
            => nameof(BillaAgent);

        protected override void Init()
        {
            var banana = new Item(ItemType.Banana, 2, Currency.JPY);
            AvailableItems.Add(banana);
            var pear = new Item(ItemType.Pear, 4, Currency.JPY);
            AvailableItems.Add(pear);
            var chocolate = new Item(ItemType.Chocolate, 3, Currency.JPY);
            AvailableItems.Add(chocolate);
            var cookies = new Item(ItemType.Cookies, 3, Currency.JPY);
            AvailableItems.Add(cookies);
        }
    }
    
    internal class ReweAgent : AbstractShop{
        public override string AsHtml()
            => nameof(ReweAgent);

        protected override void Init()
        {
            var banana = new Item(ItemType.Banana, 1, Currency.JPY);
            AvailableItems.Add(banana);
            var rice = new Item(ItemType.Rice, 3, Currency.JPY);
            AvailableItems.Add(rice);
            var chocolate = new Item(ItemType.Chocolate, 3, Currency.JPY);
            AvailableItems.Add(chocolate);
            var cookies = new Item(ItemType.Cookies, 1, Currency.JPY);
            AvailableItems.Add(cookies);
            var fish = new Item(ItemType.Fish, 2, Currency.JPY);
            AvailableItems.Add(fish);
            var pear = new Item(ItemType.Pear, 1, Currency.JPY);
            AvailableItems.Add(pear);
        }
    }
    
    internal class KauflandAgent : AbstractShop{
        public override string AsHtml()
            => nameof(KauflandAgent);

        protected override void Init()
        {
            var oil = new Item(ItemType.Oil, 1, Currency.JPY);
            AvailableItems.Add(oil);
            var salt = new Item(ItemType.Salt, 3, Currency.JPY);
            AvailableItems.Add(salt);
            var pepper = new Item(ItemType.Pepper, 3, Currency.JPY);
            AvailableItems.Add(pepper);
            var ginger = new Item(ItemType.Ginger, 1, Currency.JPY);
            AvailableItems.Add(ginger);
        }
    }
    
    internal class BillaPlusAgent : AbstractShop{
        public override string AsHtml()
            => nameof(BillaPlusAgent);

        protected override void Init()
        {
            var oil = new Item(ItemType.Oil, 2, Currency.JPY);
            AvailableItems.Add(oil);
            var salt = new Item(ItemType.Salt, 3, Currency.JPY);
            AvailableItems.Add(salt);
            var pepper = new Item(ItemType.Pepper, 4, Currency.JPY);
            AvailableItems.Add(pepper);
            var ginger = new Item(ItemType.Ginger, 0, Currency.JPY);
            AvailableItems.Add(ginger);
            
            var mustard = new Item(ItemType.Mustard, 2, Currency.JPY);
            AvailableItems.Add(mustard);
            var ketchup = new Item(ItemType.Ketchup, 2, Currency.JPY);
            AvailableItems.Add(ketchup);
            var mayonnaise = new Item(ItemType.Mayonnaise, 3, Currency.JPY);
            AvailableItems.Add(mayonnaise);
        }
    }
    
    internal class PennyAgent : AbstractShop{
        public override string AsHtml()
            => nameof(PennyAgent);

        protected override void Init()
        {
            var ketchup = new Item(ItemType.Ketchup, 6, Currency.JPY);
            AvailableItems.Add(ketchup);
            var mayonnaise = new Item(ItemType.Mayonnaise, 6, Currency.JPY);
            AvailableItems.Add(mayonnaise);
        }
    }
    
    internal class NormaAgent : AbstractShop{
        public override string AsHtml()
            => nameof(NormaAgent);

        protected override void Init()
        {
            var banana = new Item(ItemType.Banana, 4, Currency.JPY);
            AvailableItems.Add(banana);
            var pear = new Item(ItemType.Pear, 2, Currency.JPY);
            AvailableItems.Add(pear);
            var chocolate = new Item(ItemType.Chocolate, 3, Currency.JPY);
            AvailableItems.Add(chocolate);
            var cookies = new Item(ItemType.Cookies, 1, Currency.JPY);
            AvailableItems.Add(cookies);
        }
    }
}