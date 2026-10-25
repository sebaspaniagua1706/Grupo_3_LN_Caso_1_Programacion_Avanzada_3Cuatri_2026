using PAP.Business;
using System.Web.Mvc;

namespace PAP.Mvc.Controllers
{
    public class PublishersController : Controller
    {
        private readonly PublisherManager _manager;

        public PublishersController()
        {
            _manager = new PublisherManager();
        }

        public ActionResult Index()
        {
            return View(_manager.GetTop100());
        }
    }
}
