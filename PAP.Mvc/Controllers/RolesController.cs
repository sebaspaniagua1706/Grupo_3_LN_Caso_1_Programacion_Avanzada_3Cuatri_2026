using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager _manager;

        public RolesController()
        {
            _manager = new RoleManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
