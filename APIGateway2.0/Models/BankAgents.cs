using System;
using System.Threading.Tasks;

namespace Models
{
    public abstract class AbstractBank : IBankAgent{
        internal readonly Random Rand = new Random();
        public abstract Task<long> ConvertTo(long price, Currency from, Currency to);
    }
    
    internal class RaikaAgent : AbstractBank{
        public override async Task<long> ConvertTo(long price, Currency from, Currency to)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return price;
        }
    }
    
    internal class VolksAgent : AbstractBank{
        public override async Task<long> ConvertTo(long price, Currency from, Currency to)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return price;
        }
    }
    
    internal class SparkaAgent : AbstractBank{
        public override async Task<long> ConvertTo(long price, Currency from, Currency to)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return price;
        }
    }
    
    internal class OberAgent : AbstractBank{
        public override async Task<long> ConvertTo(long price, Currency from, Currency to)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return price;
        }
    }
}