using System;
using System.Threading.Tasks;

namespace APIGateway2._0.Models
{
    public class BankAgent : Agent {
        private static readonly double[,] conversionTable = {
            {1.00, 1.04, 145.00, 0.87, 1.54, 1.38, 0.98}, //EUR
            {0.96, 1.00, 139.00, 0.84, 1.48, 1.33, 0.94}, //USD
            {0.0069, 0.0072, 1.00, 0.006, 0.011, 0.0095, 0.0067}, //JPY
            {1.14, 1.19, 166.00, 1.00, 1.76, 1.58, 1.12}, //GBP
            {0.65, 0.68, 94.00, 0.57, 1.00, 0.90, 0.64}, //AUD
            {0.72, 0.75, 105.00, 0.63, 1.11, 1.00, 0.71}, //CAD
            {1.02, 1.06, 144.00, 0.89, 1.57, 1.41, 1.00}  //CHF
        };
        private readonly Func<long, Currency, Currency, Task<long>> convert;

        public BankAgent() {}

        public BankAgent(string name, string description, Func<long, Currency, Currency, Task<long>> converter) : base(name, description)
        {
            convert = converter;
        }

        public async Task<long> Convert(long price, Currency from, Currency to)
        {
            return await convert(price, from, to);
        }

        public static double Table(Currency from, Currency to)
            => conversionTable[(int)from, (int)to];
    }
}