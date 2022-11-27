using System.Collections.Generic;
using APIGateway.Models.Exceptions;

namespace APIGateway.Models
{
    public class AgentHub
    {
        private readonly Dictionary<string, BankAgent> _bankAgentList = new Dictionary<string, BankAgent>();
        private readonly Dictionary<string, ShopAgent> _shopAgentList = new Dictionary<string, ShopAgent>();

        public ICollection<ShopAgent> Shops() =>
            _shopAgentList.Values;

        public ICollection<BankAgent> Banks() =>
            _bankAgentList.Values;

        public Agent GetAgent(string name)
        {
            if (_bankAgentList.ContainsKey(name)) return _bankAgentList[name];
            if (_shopAgentList.ContainsKey(name)) return _shopAgentList[name];
            throw new NoSuchAgentException(name + " could not be found in " + nameof(AgentHub) + ".");
        }

        public void RegisterAgent(Agent agent)
        {
            switch (agent)
            {
                case BankAgent bankAgent:
                    _bankAgentList.Add(agent.Name, bankAgent);
                    break;
                case ShopAgent shopAgent:
                    _shopAgentList.Add(agent.Name, shopAgent);
                    break;
            }
        }

        public void UnregisterAgent(Agent agent)
        {
            switch (agent)
            {
                case BankAgent bankAgent:
                    _bankAgentList.Remove(bankAgent.Name);
                    break;
                case ShopAgent shopAgent:
                    _shopAgentList.Remove(shopAgent.Name);
                    break;
            }
        }
    }
}