using System;

namespace APIGateway.Models.Exceptions
{
    public class ProductNotAvailableException : Exception
    {
        public ProductNotAvailableException(string message) : base(message)
        {
        }
    }
}