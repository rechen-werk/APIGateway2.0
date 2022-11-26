using System;

namespace APIGateway.Models.Exceptions
{
    public class NoSuchAgentException : Exception
    {
        public NoSuchAgentException(string message) : base(message)
        {
        }
    }
}