using System.Linq;
using System.Web.Mvc;
using APIGateway2._0.Models;

namespace APIGateway2._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgentHub _hub = new AgentHub();

        public ActionResult Index() =>
            View();

        public ActionResult BankAgents()
        {
            ViewData["banks"] = _hub.Banks;
            return View();
        }

        public ActionResult ShopAgents()
        {
            ViewData["shops"] = _hub.Shops;
            return View();
        }

        public ActionResult CaseStudy() =>
            View();

        public ActionResult BankVisualizer(string bank) =>
            View((BankAgent)_hub.GetAgent(bank));

        public ActionResult ShopVisualizer(string shop) =>
            View((ShopAgent)_hub.GetAgent(shop));
    }
}