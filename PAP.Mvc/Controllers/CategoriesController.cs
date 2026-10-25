using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryManager _manager;

        public CategoriesController()
        {
            _manager = new CategoryManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
