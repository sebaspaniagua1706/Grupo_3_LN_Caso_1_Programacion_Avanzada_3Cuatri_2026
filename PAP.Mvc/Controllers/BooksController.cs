using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookManager _manager;

        public BooksController()
        {
            _manager = new BookManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
