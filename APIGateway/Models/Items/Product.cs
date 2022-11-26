namespace APIGateway.Models
{
    public sealed class Product
    {
        public Product(Item type, long price, Currency currency)
        {
            Type = type;
            Price = price;
            Currency = currency;
        }

        public long Price { get; }
        public Currency Currency { get; }
        public Item Type { get; }
    }
}