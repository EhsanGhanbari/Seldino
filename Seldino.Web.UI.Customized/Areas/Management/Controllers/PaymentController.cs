using System;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.PayementHandler;
using Seldino.Application.Query.PaymentService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Areas.Management.Controllers
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

        /// <summary>
        /// payment history of manager
        /// </summary>
        /// <returns></returns>
        public ActionResult History()
        {
            var payment = _paymentQueryService.GetPaymentHistory(new PaymentsQueryRequset(1, PageSize));
            return View("History", payment);
        }

        public ActionResult Detail(Guid paymentId)
        {
            var payment = _paymentQueryService.GetPaymentDetailById(new PaymentQueryRequest(paymentId));
            return View("Detail", payment);
        }

        /// <summary>
        /// User will select the system plans an will be redirected to the bank payment page
        /// </summary>
        /// <returns></returns>
        public ActionResult Charge()
        {
            return View("Charge");
        }

        [HttpPost]
        public ActionResult Charge(ChargeAccountCommand command)
        {
            if (!ModelState.IsValid) return View("Charge");
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }
    }
}