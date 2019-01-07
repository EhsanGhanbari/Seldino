using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.DiscountHandler;
using Seldino.Application.Query.DiscountService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    public class DiscountController : BaseController
    {
        private readonly IDiscountQueryService _discountQueryService;
        private readonly ICommandBus _commandBus;

        public DiscountController(IDiscountQueryService discountQueryService, ICommandBus commandBus)
        {
            _discountQueryService = discountQueryService;
            _commandBus = commandBus;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var query = new DiscountQueryRequest(1,20);
            var discounts = _discountQueryService.GetAllDiscounts( query);
            return View(discounts);
        }

        public ActionResult Delete(DeleteDiscountCommand command)
        {
            var result = _commandBus.Send(command);
            return View(result);
        }

        
	}
}