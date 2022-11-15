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
            ViewBag.Banks = _hub.Banks;
            return View();
        }

        public ActionResult ShopAgents()
        {
            ViewBag.Shops = _hub.Shops;
            return View();
        }

        public ActionResult CaseStudy() =>
            View();
    }
}