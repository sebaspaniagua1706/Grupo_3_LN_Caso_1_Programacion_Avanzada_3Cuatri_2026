using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SupplierManager _manager;

        public SuppliersController()
        {
            _manager = new SupplierManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
