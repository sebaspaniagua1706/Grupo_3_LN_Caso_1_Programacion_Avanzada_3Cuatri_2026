using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorManager _manager;

        public AuthorsController()
        {
            _manager = new AuthorManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
