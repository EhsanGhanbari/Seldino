using System.Web.Mvc;
using Seldino.Application.Query.DashboardService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Areas.Management.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        private readonly IDashboardQueryService _dashboardQueryService;

        public DashboardController(IDashboardQueryService dashboardQueryService)
        {
            _dashboardQueryService = dashboardQueryService;
        }

        public ActionResult Index()
        {
            var response = _dashboardQueryService.GetDashboardLayout(new DashboardLayoutQueryRequest(CurrentUser.Id));
            return View("Index", response);
        }
    }
}