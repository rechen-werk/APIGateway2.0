using System.Collections.Generic;

namespace AgentAbstraction
{
    public interface IBankAgent
    {
        long ConvertTo(long price, Currency from, Currency to);
    }
    public interface IShopAgent
    {
        List<(Item, int)> GetItemsWithQuantity();
    }
}