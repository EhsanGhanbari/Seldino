using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Query.ProductService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.API.Areas.Management.Controllers
{
    public class ProductManagerController : BaseApiController
    {
        private readonly ICommandBus _commandBus;
        private readonly IProductQueryService _productQueryService;

        public ProductManagerController(ICommandBus commandBus, IProductQueryService productQueryService)
        {
            _commandBus = commandBus;
            _productQueryService = productQueryService;
        }

    }
}
