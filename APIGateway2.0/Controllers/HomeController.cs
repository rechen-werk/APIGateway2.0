using System.Linq;
using System.Web.Mvc;
using Agent;
using Models;

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
            ViewBag.Shops = _hub.Shops.Select(it => it.AsHtml());
            return View();
        }

        public ActionResult CaseStudy() =>
            View();

        public ActionResult BankVisualizer(IBankAgent bankAgent)
        {
            switch (bankAgent)
            {
                case VeryExpensiveBank agent: return View(agent);
                case ExpensiveBank agent: return View(agent);
                case FairBank agent: return View(agent);
                case UnresponsiveBank agent: return View(agent);
                case CheapBank agent: return View(agent);
                case QuiteExpensiveBank agent: return View(agent);
                default: return View(bankAgent);
            }
        }
    }
}