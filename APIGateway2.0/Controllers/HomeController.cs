using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APIGateway2._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BankAgents()
        {
            return View();
        }

        public ActionResult ShopAgents()
        {
            return View();
        }
    }
}