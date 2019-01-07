using System.Net;
using System.Net.Http;
using System.Web.Http;
using Seldino.Application.Query.StoreService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.API.Controllers
{
    public class StoreController : BaseApiController
    {

        private readonly IStoreQueryService _storeQueryService;

        public StoreController(IStoreQueryService storeQueryService)
        {
            _storeQueryService = storeQueryService;
        }

        [HttpGet]
        public HttpResponseMessage GetStores(string keyword)
        {
            var query = new StoresQueryRequest(keyword);
            var stores = _storeQueryService.GetStores(query);
            return Request.CreateResponse(stores == null ? HttpStatusCode.NoContent : HttpStatusCode.OK);
        }

    }
}
