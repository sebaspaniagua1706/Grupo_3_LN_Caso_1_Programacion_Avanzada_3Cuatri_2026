using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeManager _manager;

        public EmployeesController()
        {
            _manager = new EmployeeManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
