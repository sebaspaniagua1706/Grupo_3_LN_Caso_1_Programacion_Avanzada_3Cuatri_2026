using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerManager _manager;

        public CustomersController()
        {
            _manager = new CustomerManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
