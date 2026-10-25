using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly ShoppingCartManager _manager;

        public ShoppingCartsController()
        {
            _manager = new ShoppingCartManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
