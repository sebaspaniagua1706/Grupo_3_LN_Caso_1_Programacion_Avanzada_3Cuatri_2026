using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class CartItemsController : Controller
    {
        private readonly CartItemManager _manager;

        public CartItemsController()
        {
            _manager = new CartItemManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
