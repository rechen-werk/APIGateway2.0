using System.Collections.Generic;

namespace AgentAbstraction
{
    public interface IAgent{ }
    public interface IBankAgent : IAgent
    {
        long ConvertTo(long price, Currency from, Currency to);
    }
    public interface IShopAgent : IAgent
    {
        List<(Item, int)> GetItemsWithQuantity();
    }
}