using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class BookAuthorsController : Controller
    {
        private readonly BookAuthorManager _manager;

        public BookAuthorsController()
        {
            _manager = new BookAuthorManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
