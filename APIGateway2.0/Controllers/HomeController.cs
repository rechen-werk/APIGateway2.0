using System.Threading.Tasks;
using System.Web.Mvc;
using APIGateway2._0.Models;

namespace APIGateway2._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgentHub _hub = new AgentHub();

        public async Task<ActionResult> Index() =>
            View();

        public async Task<ActionResult> BankAgents()
        {
            ViewData["banks"] = _hub.Banks;
            return View();
        }

        public async Task<ActionResult> ShopAgents()
        {
            ViewData["shops"] = _hub.Shops;
            return View();
        }

        public async Task<ActionResult> CaseStudy() =>
            View();

        public async Task<ActionResult> BankVisualizer(string bank) =>
            View((BankAgent)_hub.GetAgent(bank));

        public async Task<ActionResult> ShopVisualizer(string shop) =>
            View((ShopAgent)_hub.GetAgent(shop));
    }
}