using System.Web.Http;
using Seldino.Application.Query.OrderService;

namespace Seldino.Web.API.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderQueryService _orderQueryService;

        public OrderController(IOrderQueryService orderQueryService)
        {
            _orderQueryService = orderQueryService;
        }

    }
}
