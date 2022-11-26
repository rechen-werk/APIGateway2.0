using System.Threading.Tasks;

namespace APIGateway.Models
{
    public class PrefilledAgentHub : AgentHub
    {
        public PrefilledAgentHub()
        {
            RegisterAgent(
                new BankAgent(
                    "VeryExpensiveBank",
                    "Takes 50% of your money.",
                    async (price, from, to)
                        =>
                    {
                        await Task.Delay(Half.A.Second());
                        return (long)(price * 0.5 * BankAgent.Table(from, to));
                    }
                )
            );

            RegisterAgent(
                new BankAgent(
                    "QuiteExpensiveBank",
                    "Takes 30% of your money.",
                    async (price, from, to)
                        =>
                    {
                        await Task.Delay(1.Second());
                        return (long)(price * 0.7 * BankAgent.Table(from, to));
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
                        =>
                    {
                        await Task.Delay(1.5.Seconds());
                        return (long)(price * 0.95 * BankAgent.Table(from, to));
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
                        await Task.Delay(Quarter.A.Second());
                        return (long)(price * BankAgent.Table(from, to));
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
                        await Task.Delay(1.Second());
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
                        await Task.Delay(0.31415.Seconds());
                        return (long)(price * 0.95 * BankAgent.Table(from, to));
                    })
            );


            RegisterAgent(
                new ShopAgent(
                    "HoferAgent",
                    "Sells a few items.",
                    (new Product(Item.Eggs, 3, Currency.USD), 5),
                    (new Product(Item.Butter, 3, Currency.USD), 7),
                    (new Product(Item.Bacon, 3, Currency.USD), 12)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "SparAgent",
                    "Sells a few items.",
                    (new Product(Item.Eggs, 2, Currency.EUR), 11),
                    (new Product(Item.Butter, 3, Currency.EUR), 5),
                    (new Product(Item.Bacon, 1, Currency.EUR), 4),
                    (new Product(Item.Apple, 3, Currency.EUR), 7)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "LidlAgent",
                    "Sells a few items.",
                    (new Product(Item.Banana, 3, Currency.CAD), 8),
                    (new Product(Item.Pear, 3, Currency.CAD), 22),
                    (new Product(Item.Grapes, 3, Currency.CAD), 14),
                    (new Product(Item.Avocado, 3, Currency.CAD), 1)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "BillaAgent",
                    "Sells a few items.",
                    (new Product(Item.Banana, 2, Currency.JPY), 3),
                    (new Product(Item.Pear, 4, Currency.JPY), 9),
                    (new Product(Item.Chocolate, 3, Currency.JPY), 8),
                    (new Product(Item.Cookies, 3, Currency.JPY), 15)
                )
            );

            RegisterAgent(
                new ShopAgent(
                    "ReweAgent",
                    "Sells a few items.",
                    (new Product(Item.Banana, 1, Currency.JPY), 7),
                    (new Product(Item.Rice, 3, Currency.JPY), 2),
                    (new Product(Item.Chocolate, 3, Currency.JPY), 4),
                    (new Product(Item.Cookies, 1, Currency.JPY), 7),
                    (new Product(Item.Fish, 2, Currency.JPY), 12),
                    (new Product(Item.Pear, 1, Currency.JPY), 40)
                )
            );
            RegisterAgent(
                new ShopAgent(
                    "KauflandAgent",
                    "Sells a few items.",
                    (new Product(Item.Oil, 1, Currency.JPY), 1),
                    (new Product(Item.Salt, 3, Currency.JPY), 2),
                    (new Product(Item.Pepper, 3, Currency.JPY), 3),
                    (new Product(Item.Ginger, 1, Currency.JPY), 4)
                )
            );
            RegisterAgent(
                new ShopAgent(
                    "BillaPlusAgent",
                    "Sells a few items.",
                    (new Product(Item.Oil, 2, Currency.JPY), 3),
                    (new Product(Item.Salt, 3, Currency.JPY), 7),
                    (new Product(Item.Pepper, 4, Currency.JPY), 9),
                    (new Product(Item.Ginger, 0, Currency.JPY), 8),
                    (new Product(Item.Mustard, 2, Currency.JPY), 2),
                    (new Product(Item.Ketchup, 2, Currency.JPY), 6),
                    (new Product(Item.Mayonnaise, 3, Currency.JPY), 10)
                )
            );
            RegisterAgent(
                new ShopAgent(
                    "PennyAgent",
                    "Sells a few items.",
                    (new Product(Item.Ketchup, 6, Currency.JPY), 1),
                    (new Product(Item.Mayonnaise, 6, Currency.JPY), 8)
                )
            );
            RegisterAgent(
                new ShopAgent(
                    "NormaAgent",
                    "Sells a few items.",
                    (new Product(Item.Banana, 4, Currency.JPY), 10),
                    (new Product(Item.Pear, 2, Currency.JPY), 10),
                    (new Product(Item.Chocolate, 3, Currency.JPY), 7),
                    (new Product(Item.Cookies, 1, Currency.JPY), 5)
                )
            );
        }
    }
}