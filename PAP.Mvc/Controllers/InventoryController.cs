using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryManager _manager;

        public InventoryController()
        {
            _manager = new InventoryManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
