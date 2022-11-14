using System.Web.Mvc;

namespace APIGateway2._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() =>
            View();

        public ActionResult BankAgents() =>
            View();

        public ActionResult ShopAgents() =>
            View();
    }
}