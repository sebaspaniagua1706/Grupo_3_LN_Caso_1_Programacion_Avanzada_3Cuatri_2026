using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class PurchaseOrderItemsController : Controller
    {
        private readonly PurchaseOrderItemManager _manager;

        public PurchaseOrderItemsController()
        {
            _manager = new PurchaseOrderItemManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
