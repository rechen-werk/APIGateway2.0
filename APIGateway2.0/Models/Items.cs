namespace Models
{
    public sealed class Item
    {
        public long Price { get; }
        public Currency Currency { get; }
        public ItemType Type { get; }

        public Item(ItemType type, int price, Currency currency)
        {
            Type = type;
            Price = price;
            Currency = currency;
        }
    }

    public enum ItemType
    {
        Apple, Banana, Pear, Grapes, Avocado, Pineapple, Grapefruit, Watermelon, Orange, Coconut, Kiwi, Mango, Corn,
        Mushroom, Broccoli, Cucumber, Pepper, Carrot, Tomato, Cabbage, Potato, Lettuce, Onion, Radish, Spinach, Peas,
        Beans, Chili, Milk, Bread, Water, Yoghurt, Cheese, Butter, Eggs, Bacon, Pork, Beef, Sausages, Coffee, Pasta,
        Oil, Jam, Mustard, Salt, Mayonnaise, Ketchup, Ginger, Oregano, Basil, Sugar, Garlic, Flour, Vinegar, Vanilla,
        Rice, Fish, Chocolate, Chips, Cookies
    }

    public enum Currency
    {
        EUR, USD, JPY, GBP, AUD, CAD, CHF
    }

}