using System.Collections.Generic;
using System.Web.Mvc;

namespace APIGateway2._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() =>
            View();

        public ActionResult BankAgents()
        {
            ViewBag.Banks = banks;
            return View();
        }

        public ActionResult ShopAgents() =>
            View();

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
    }
}