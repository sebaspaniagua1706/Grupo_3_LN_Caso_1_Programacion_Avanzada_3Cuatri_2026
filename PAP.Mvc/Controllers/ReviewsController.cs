using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ReviewManager _manager;

        public ReviewsController()
        {
            _manager = new ReviewManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
