using System.Web.Mvc;
using Seldino.Application.Query.BannerService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Controllers
{
    public class BannerController : BaseController
    {
        private readonly IBannerQueryService _bannerQueryService;

        public BannerController(IBannerQueryService bannerQueryService)
        {
            _bannerQueryService = bannerQueryService;
        }

        [ChildActionOnly]
        [OutputCache(Duration = 6000)]
        public PartialViewResult Sliders()
        {
            var response = _bannerQueryService.GetAdvBanners(new AdvBannersQueryQueryRequest(2));
            return PartialView("Sliders", response);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 6000)]
        public PartialViewResult Fixed()
        {
            var response = _bannerQueryService.GetAdvBanners(new AdvBannersQueryQueryRequest(2));
            return PartialView("Fixed", response);
        }
    }
}