using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace APIGateway2._0.Models
{
    internal class AgentHub
    {
        private readonly Dictionary<string, ShopAgent> _shopAgentList = new Dictionary<string, ShopAgent>();
        private readonly Dictionary<string, BankAgent> _bankAgentList = new Dictionary<string, BankAgent>();

        public IList<ShopAgent> Shops =>
            _shopAgentList.Values.ToList().AsReadOnly();

        public IList<BankAgent> Banks =>
            _bankAgentList.Values.ToList().AsReadOnly();

        public AgentHub()
        {
            PseudoInit();
        }

        public Agent GetAgent(string name)
        {
            if (_bankAgentList.ContainsKey(name))
            {
                return _bankAgentList[name];
            }
            return _shopAgentList.ContainsKey(name) ? _shopAgentList[name] : null;
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

        private void PseudoInit()
        {
            RegisterAgent(
                new BankAgent(
                "VeryExpensiveBank",
                "Takes 50% of your money.",
                async (price, from, to)
                    => {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    return (long) (price * 0.5 * BankAgent.Table(from, to));
                }
                )
            );
            
            RegisterAgent(
                new BankAgent(
                "QuiteExpensiveBank",
                "Takes 30% of your money.",
                async (price, from, to)
                    => {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    return (long) (price * 0.7 * BankAgent.Table(from, to));
                }
                )
            );
            RegisterAgent(

                new BankAgent(
                "ExpensiveBank",
                "Takes 10% of your money.",
                async (price, from, to)
                    => (long)(price * 0.9 * BankAgent.Table(from, to)))
            );
            RegisterAgent(
                new BankAgent(
                "CheapBank",
                "Takes 5% of your money.",
                async (price, from, to)
                    => {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    return (long) (price * 0.95 * BankAgent.Table(from, to));
                }
                )
            );
            RegisterAgent(
                new BankAgent(
                "FairBank",
                "Takes none of your money.",
                async (price, from, to)
                    =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    return (long) (price * BankAgent.Table(from, to));
                }
                
                )
            );
            RegisterAgent(
                new BankAgent(
                "UnresponsiveBank",
                "Takes an hour to respond to each request.",
                async (price, from, to)
                    =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(3600));
                    return (long)(price * BankAgent.Table(from, to));
                })
            );
            RegisterAgent(
                new BankAgent(
                    "SlowCheapBank",
                    "Takes a second to respond to each request.",
                    async (price, from, to)
                        =>
                    {
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        return (long)(price * 0.95 * BankAgent.Table(from, to));
                    })
            );


            RegisterAgent(
                new ShopAgent(
                    "HoferAgent",
                    "Sells a few items.",
                    new Item(ItemType.Eggs, 3, Currency.USD),
                    new Item(ItemType.Butter, 3, Currency.USD),
                    new Item(ItemType.Bacon, 3, Currency.USD)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "SparAgent",
                    "Sells a few items.",
                    new Item(ItemType.Eggs, 2, Currency.EUR),
                    new Item(ItemType.Butter, 3, Currency.EUR),
                    new Item(ItemType.Bacon, 1, Currency.EUR),
                    new Item(ItemType.Apple, 3, Currency.EUR)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "LidlAgent",
                    "Sells a few items.",
                    new Item(ItemType.Banana, 3, Currency.JPY),
                    new Item(ItemType.Pear, 3, Currency.JPY),
                    new Item(ItemType.Grapes, 3, Currency.JPY),
                    new Item(ItemType.Avocado, 3, Currency.JPY)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "BillaAgent",
                    "Sells a few items.",
                    new Item(ItemType.Banana, 2, Currency.JPY),
                    new Item(ItemType.Pear, 4, Currency.JPY),
                    new Item(ItemType.Chocolate, 3, Currency.JPY),
                    new Item(ItemType.Cookies, 3, Currency.JPY)
                )
            );

            RegisterAgent(
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
            RegisterAgent(
                new ShopAgent(
                    "KauflandAgent",
                    "Sells a few items.",
                    new Item(ItemType.Oil, 1, Currency.JPY),
                    new Item(ItemType.Salt, 3, Currency.JPY),
                    new Item(ItemType.Pepper, 3, Currency.JPY),
                    new Item(ItemType.Ginger, 1, Currency.JPY)
                )
            );
            RegisterAgent(
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
            RegisterAgent(
                new ShopAgent(
                    "PennyAgent",
                    "Sells a few items.",
                    new Item(ItemType.Ketchup, 6, Currency.JPY),
                    new Item(ItemType.Mayonnaise, 6, Currency.JPY)
                )
            );
            RegisterAgent(
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