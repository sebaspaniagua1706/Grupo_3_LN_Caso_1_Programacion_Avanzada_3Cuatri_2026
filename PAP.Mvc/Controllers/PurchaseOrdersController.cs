using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private readonly PurchaseOrderManager _manager;

        public PurchaseOrdersController()
        {
            _manager = new PurchaseOrderManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
