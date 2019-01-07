using System.Web.Mvc;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    public class DashboardController : BaseController
    {
       
        public ActionResult Index()
        {
            return View();
        }
	}
}