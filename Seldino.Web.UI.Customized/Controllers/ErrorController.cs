using System.Web.Mvc;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Controllers
{
    public class ErrorController : BaseController
    {
        public ActionResult Internal()
        {
            return View();
        }

        public ActionResult Code401()
        {
            return View();
        }

        public ActionResult Code402()
        {
            return View();
        }

        public ActionResult Code403()
        {
            return View();
        }

        public ActionResult Code404()
        {
            return View();
        }
	}
}