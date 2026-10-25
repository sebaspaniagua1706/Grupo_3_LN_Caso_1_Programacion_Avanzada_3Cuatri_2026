using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly OrderItemManager _manager;

        public OrderItemsController()
        {
            _manager = new OrderItemManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
