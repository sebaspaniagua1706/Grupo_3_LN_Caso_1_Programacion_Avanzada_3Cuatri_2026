using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class GenresController : Controller
    {
        private readonly GenreManager _manager;

        public GenresController()
        {
            _manager = new GenreManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
