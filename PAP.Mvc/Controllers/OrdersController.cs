using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderManager _manager;

        public OrdersController()
        {
            _manager = new OrderManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
