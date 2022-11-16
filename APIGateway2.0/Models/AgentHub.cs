using System.Collections.Generic;
using Models;

namespace Agent
{
    internal class AgentHub
    {
        private readonly List<IShopAgent> _shopAgentList = new List<IShopAgent>();
        private readonly List<IBankAgent> _bankAgentList = new List<IBankAgent>();

        public IList<IShopAgent> Shops =>
            _shopAgentList.AsReadOnly();

        public IList<IBankAgent> Banks =>
            _bankAgentList.AsReadOnly();

        public AgentHub()
        {
            PseudoInit();
        }

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

        private void PseudoInit()
        {
            _bankAgentList.Add(new CheapBank());
            _bankAgentList.Add(new ExpensiveBank());
            _bankAgentList.Add(new VeryExpensiveBank());
            _bankAgentList.Add(new QuiteExpensiveBank());
            _bankAgentList.Add(new FairBank());
            _bankAgentList.Add(new UnresponsiveBank());

            _shopAgentList.Add(new BillaAgent());
            _shopAgentList.Add(new HoferAgent());
            _shopAgentList.Add(new SparAgent());
            _shopAgentList.Add(new LidlAgent());
            _shopAgentList.Add(new ReweAgent());
            _shopAgentList.Add(new KauflandAgent());
            _shopAgentList.Add(new BillaPlusAgent());
            _shopAgentList.Add(new PennyAgent());
            _shopAgentList.Add(new NormaAgent());
        }
    }
}