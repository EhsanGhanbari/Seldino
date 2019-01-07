using System;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.PayementHandler;
using Seldino.Application.Query.PaymentService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    [Authorize]
    public class PaymentController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IPaymentQueryService _paymentQueryService;

        public PaymentController(ICommandBus commandBus, IPaymentQueryService paymentQueryService)
        {
            _commandBus = commandBus;
            _paymentQueryService = paymentQueryService;
        }

        public ActionResult List(int pageIndex)
        {
            var requset = new PaymentsQueryRequset(pageIndex, PageSize);
            var response = _paymentQueryService.GetPayments(requset);
            return View("List", response);
        }

        public ActionResult History(Guid userId, int pageIndex)
        {
            var requset = new PaymentsQueryRequset(pageIndex, PageSize, userId);
            var response = _paymentQueryService.GetPaymentHistory(requset);
            return View("History", response);
        }

        public ActionResult Detail(Guid paymentId)
        {
            var request = new PaymentQueryRequest(paymentId);
            var response = _paymentQueryService.GetPaymentDetailById(request);
            return View("Detail",response);
        }

        [HttpPost]
        public ActionResult Delete(DeletePaymentCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }
    }
}