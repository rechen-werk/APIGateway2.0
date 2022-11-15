using System.Collections.Generic;
using System.Web.Mvc;
using AgentAbstraction;

namespace APIGateway2._0.Controllers
{
    public class HomeController : Controller
    {
        private List<IAgent> _registeredAgents = new List<IAgent>();

        public ActionResult Index() =>
            View();

        public ActionResult BankAgents()
        {
            ViewBag.Banks = banks;
            return View();
        }

        public ActionResult ShopAgents()
        {
            ViewBag.Shops = shops;
            return View();
        }

        public ActionResult CaseStudy() =>
            View();

        //---Temporary Lists to simulate Data that lukas will provide---------------------------------------------------

        private List<string> banks = new List<string>
        {
            "Raiffeisenbank",
            "Volksbank",
            "Sparkasse",
            "Oberbank"
        };

        private List<string> shops = new List<string>
        {
            "Hofer",
            "Spar",
            "Lidl",
            "Billa",
            "Rewe",
            "Kaufland",
            "Merkur",
            "Penny",
            "Norma"
        };
    }
}