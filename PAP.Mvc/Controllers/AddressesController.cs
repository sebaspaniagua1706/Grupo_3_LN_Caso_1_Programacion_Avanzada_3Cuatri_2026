using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class AddressesController : Controller
    {
        private readonly AddressManager _manager;

        public AddressesController()
        {
            _manager = new AddressManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
