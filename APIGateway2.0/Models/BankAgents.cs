using System;
using System.Threading.Tasks;

namespace Models
{
    public abstract class AbstractBank : IBankAgent{
        internal readonly Random Rand = new Random();
        public abstract Task<long> ConvertTo(long price, Currency from, Currency to);
        public abstract string AsHtml();
    }
    
    internal class RaikaAgent : AbstractBank{
        public override async Task<long> ConvertTo(long price, Currency from, Currency to)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return price;
        }

        public override string AsHtml()
            => nameof(RaikaAgent);
    }
    
    internal class VolksAgent : AbstractBank{
        public override async Task<long> ConvertTo(long price, Currency from, Currency to)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return price;
        }

        public override string AsHtml()
            => nameof(VolksAgent);
    }
    
    internal class SparkaAgent : AbstractBank{
        public override async Task<long> ConvertTo(long price, Currency from, Currency to)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return price;
        }

        public override string AsHtml()
            => nameof(SparAgent);
    }
    
    internal class OberAgent : AbstractBank{
        public override async Task<long> ConvertTo(long price, Currency from, Currency to)
        {
            await Task.Delay(TimeSpan.FromSeconds(Rand.Next()));

            return price;
        }

        public override string AsHtml()
            => nameof(OberAgent);
    }
}