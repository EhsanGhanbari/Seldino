using Seldino.Application.Query.BannerService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.API.Controllers
{
    public class BannerController : BaseApiController
    {
        private readonly IBannerQueryService _bannerQueryService;

        public BannerController(IBannerQueryService bannerQueryService)
        {
            _bannerQueryService = bannerQueryService;
        }


    }
}