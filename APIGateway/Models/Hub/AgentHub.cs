using System.Collections.Generic;
using System.Threading.Tasks;
using APIGateway.Models.Exceptions;
using CF.Collections.Generic;

namespace APIGateway.Models
{
    public class AgentHub
    {
        private readonly AsyncDictionary<string, BankAgent> _bankAgentList = new AsyncDictionary<string, BankAgent>();
        private readonly AsyncDictionary<string, ShopAgent> _shopAgentList = new AsyncDictionary<string, ShopAgent>();

        public async Task<ICollection<ShopAgent>> Shops() =>
            await _shopAgentList.GetValuesAsync();

        public async Task<ICollection<BankAgent>> Banks() =>
            await _bankAgentList.GetValuesAsync();

        public async Task<Agent> GetAgent(string name)
        {
            if (await _bankAgentList.GetContainsKeyAsync(name)) return await _bankAgentList.GetValueAsync(name);
            if (await _shopAgentList.GetContainsKeyAsync(name)) return await _shopAgentList.GetValueAsync(name);
            throw new NoSuchAgentException(name + " could not be found in " + nameof(AgentHub) + ".");
        }

        public async void RegisterAgent(Agent agent)
        {
            switch (agent)
            {
                case BankAgent bankAgent:
                    await _bankAgentList.AddAsync(agent.Name, bankAgent);
                    break;
                case ShopAgent shopAgent:
                    await _shopAgentList.AddAsync(agent.Name, shopAgent);
                    break;
            }
        }

        public async void UnregisterAgent(Agent agent)
        {
            switch (agent)
            {
                case BankAgent bankAgent:
                    await _bankAgentList.RemoveAsync(bankAgent.Name);
                    break;
                case ShopAgent shopAgent:
                    await _shopAgentList.RemoveAsync(shopAgent.Name);
                    break;
            }
        }
    }
}