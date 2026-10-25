using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly PaymentManager _manager;

        public PaymentsController()
        {
            _manager = new PaymentManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
