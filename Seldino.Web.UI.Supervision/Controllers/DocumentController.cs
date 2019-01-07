using System.Web.Mvc;

namespace Seldino.Web.UI.Supervision.Controllers
{
    public class DocumentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rules()
        {
            return View();
        }

        public ActionResult Rules(dynamic rules)
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult About(dynamic about)
        {
            return View();
        }

        public ActionResult Notification()
        {
            return View();
        }
	}
}