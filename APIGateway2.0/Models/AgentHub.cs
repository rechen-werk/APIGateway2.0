using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIGateway2._0.Models
{
    internal class AgentHub
    {
        private readonly List<ShopAgent> _shopAgentList = new List<ShopAgent>();
        private readonly List<BankAgent> _bankAgentList = new List<BankAgent>();

        public IList<ShopAgent> Shops =>
            _shopAgentList.AsReadOnly();

        public IList<BankAgent> Banks =>
            _bankAgentList.AsReadOnly();

        public AgentHub()
        {
            PseudoInit();
        }

        public void RegisterAgent(Agent agent)
        {
            switch (agent)
            {
               case BankAgent bankAgent:
                   _bankAgentList.Add(bankAgent);
                   break;
               case ShopAgent shopAgent:
                   _shopAgentList.Add(shopAgent);
                   break;
            }
        }

        public void UnregisterAgent(Agent agent)
        {
            switch (agent)
            {
                case BankAgent bankAgent:
                    _bankAgentList.Remove(bankAgent);
                    break;
                case ShopAgent shopAgent:
                    _shopAgentList.Remove(shopAgent);
                    break;
            }
        }

        private void PseudoInit()
        {
            _bankAgentList.Add(
                new BankAgent(
                "VeryExpensiveBank",
                "Takes 50% of your money.",
                async (price, from, to)
                    =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(BankAgent.Rand.Next(0,30)));
                    return (long)(price * 1.5 * BankAgent.Table(from, to));
                })
            );
            _bankAgentList.Add(
                new BankAgent(
                "QuiteExpensiveBank",
                "Takes 30% of your money.",
                async (price, from, to)
                    =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(BankAgent.Rand.Next(0,30)));
                    return (long)(price * 1.3 * BankAgent.Table(from, to));
                })
            );
            _bankAgentList.Add(
                new BankAgent(
                "ExpensiveBank",
                "Takes 10% of your money.",
                async (price, from, to)
                    =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(BankAgent.Rand.Next(0,30)));
                    return (long)(price * 1.1 * BankAgent.Table(from, to));
                })
            );
            _bankAgentList.Add(
                new BankAgent(
                "CheapBank",
                "Takes 5% of your money.",
                async (price, from, to)
                    =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(BankAgent.Rand.Next(0,30)));
                    return (long)(price * 1.05 * BankAgent.Table(from, to));
                })
            );
            _bankAgentList.Add(
                new BankAgent(
                "FairBank",
                "Takes none of your money.",
                async (price, from, to)
                    =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(BankAgent.Rand.Next(0,30)));
                    return (long)(price * BankAgent.Table(from, to));
                })
            );
            _bankAgentList.Add(
                new BankAgent(
                "UnresponsiveBank",
                "Never responds to requests.",
                async (price, from, to)
                    =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(Double.MaxValue));
                    return (long)(price * BankAgent.Table(from, to));
                })
            );

            _shopAgentList.Add(
                new ShopAgent(
                    "HoferAgent",
                    "Sells a few items.",
                    new Item(ItemType.Eggs, 3, Currency.USD),
                    new Item(ItemType.Butter, 3, Currency.USD),
                    new Item(ItemType.Bacon, 3, Currency.USD)
                )
            );
            _shopAgentList.Add(
                new ShopAgent(
                    "SparAgent",
                    "Sells a few items.",
                    new Item(ItemType.Eggs, 2, Currency.EUR),
                    new Item(ItemType.Butter, 3, Currency.EUR),
                    new Item(ItemType.Bacon, 1, Currency.EUR),
                    new Item(ItemType.Apple, 3, Currency.EUR)
                )
            );
            _shopAgentList.Add(
                new ShopAgent(
                    "LidlAgent",
                    "Sells a few items.",
                    new Item(ItemType.Banana, 3, Currency.JPY),
                    new Item(ItemType.Pear, 3, Currency.JPY),
                    new Item(ItemType.Grapes, 3, Currency.JPY),
                    new Item(ItemType.Avocado, 3, Currency.JPY)
                )
            );
            _shopAgentList.Add(
                new ShopAgent(
                    "BillaAgent",
                    "Sells a few items.",
                    new Item(ItemType.Banana, 2, Currency.JPY),
                    new Item(ItemType.Pear, 4, Currency.JPY),
                    new Item(ItemType.Chocolate, 3, Currency.JPY),
                    new Item(ItemType.Cookies, 3, Currency.JPY)
                )
            );
            _shopAgentList.Add(
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
            _shopAgentList.Add(
                new ShopAgent(
                    "KauflandAgent",
                    "Sells a few items.",
                    new Item(ItemType.Oil, 1, Currency.JPY),
                    new Item(ItemType.Salt, 3, Currency.JPY),
                    new Item(ItemType.Pepper, 3, Currency.JPY),
                    new Item(ItemType.Ginger, 1, Currency.JPY)
                )
            );
            _shopAgentList.Add(
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
            _shopAgentList.Add(
                new ShopAgent(
                    "PennyAgent",
                    "Sells a few items.",
                    new Item(ItemType.Ketchup, 6, Currency.JPY),
                    new Item(ItemType.Mayonnaise, 6, Currency.JPY)
                )
            );
            _shopAgentList.Add(
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
    }
}