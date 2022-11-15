using System.Collections.Generic;
using AgentAbstraction;

namespace APIGateway2._0.Models
{
    internal class AgentHub
    {
        private List<IShopAgent> _shopAgentList = new List<IShopAgent>();
        private List<IBankAgent> _bankAgentList = new List<IBankAgent>();

        public IList<IShopAgent> Shops =>
            _shopAgentList.AsReadOnly();

        public IList<IBankAgent> Banks =>
            _bankAgentList.AsReadOnly();

        public void RegisterAgent(IAgent agent)
        {
            switch (agent)
            {
               case IBankAgent bankAgent:
                   _bankAgentList.Add(bankAgent);
                   break;
               case IShopAgent shopAgent:
                   _shopAgentList.Add(shopAgent);
                   break;
            }
        }

        public void UnregisterAgent(IAgent agent)
        {
            switch (agent)
            {
                case IBankAgent bankAgent:
                    _bankAgentList.Remove(bankAgent);
                    break;
                case IShopAgent shopAgent:
                    _shopAgentList.Remove(shopAgent);
                    break;
            }
        }


    }
}