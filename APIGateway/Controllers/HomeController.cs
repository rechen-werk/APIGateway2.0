using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using APIGateway.Models;

namespace APIGateway.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgentHub _hub;
        private readonly CaseStudy _caseStudy;

        public HomeController()
        {
            _hub = new PrefilledAgentHub();
            _caseStudy = new CaseStudy(_hub);
            ViewData["banks"] = new List<BankAgent>();
            ViewData["shops"] = new List<ShopAgent>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BankAgents()
        {
            Task.Run(async() => ViewData["banks"] = (await _hub.Banks()).ToList());

            return View();
        }

        public  ActionResult ShopAgents()
        {
            Task.Run(async() => ViewData["shops"] = (await _hub.Shops()).ToList());
            return View();
        }

        public ActionResult CaseStudy()
        {
            ViewData["hub"] = _hub;
            return View();
        }

        public ActionResult BankVisualizer(string bank)
        {
            return View((BankAgent)  _hub.GetAgent(bank).Result);
        }

        public ActionResult ShopVisualizer(string shop)
        {
            return View((ShopAgent) _hub.GetAgent(shop).Result);
        }

        public ActionResult ClickCaseStudyButton()
        {
            var start = DateTime.UtcNow;
            var val =  _caseStudy.CheapestConvert(1, Currency.EUR, Currency.USD).Result;
            var end = DateTime.UtcNow;
            var timeDiff = end - start;
            Console.WriteLine(Convert.ToInt32(timeDiff.TotalMilliseconds));
            Console.WriteLine(val);
            return View("CaseStudy");
        }
    }
}