namespace APIGateway.Models
{
    public sealed class Product
    {
        public Product(Item type, double price, Currency currency)
        {
            Type = type;
            Price = price;
            Currency = currency;
        }

        public double Price { get; }
        public Currency Currency { get; }
        public Item Type { get; }
    }
}