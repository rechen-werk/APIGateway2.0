using System.Linq;
using System.Web.Mvc;
using Agent;

namespace APIGateway2._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgentHub _hub = new AgentHub();

        public ActionResult Index() =>
            View();

        public ActionResult BankAgents()
        {
            ViewBag.Banks = _hub.Banks.Select(it => it.AsHtml());
            return View();
        }

        public ActionResult ShopAgents()
        {
            ViewBag.Shops = _hub.Shops.Select(it => it.AsHtml());
            return View();
        }

        public ActionResult CaseStudy() =>
            View();
    }
}