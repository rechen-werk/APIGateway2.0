using System;

namespace APIGateway.Models.Exceptions
{
    public class PriceNegativeException : Exception
    {
        public PriceNegativeException(string message) : base(message)
        {
        }
    }
}