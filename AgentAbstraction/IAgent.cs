using System.Collections.Generic;

namespace AgentAbstraction
{
    public interface IBankAgent
    {
        int convertTo(int price, Currency from, Currency to);
    }
    public interface IShopAgent
    {
        List<(Item, int)> getItemsWithQuantity();
    }
}