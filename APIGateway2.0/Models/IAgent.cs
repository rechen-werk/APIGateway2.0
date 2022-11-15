using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models
{
    public interface IAgent
    {
        string AsHtml();
    }
    public interface IBankAgent : IAgent {
        Task<long> ConvertTo(long price, Currency from, Currency to);
    }
    public interface IShopAgent : IAgent {
        Task<List<(Item, int)>> GetItemsWithQuantity();
    }
}