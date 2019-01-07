using System;
using System.Web.Mvc;
using System.Web.UI;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.OrderHandler;
using Seldino.Application.Command.PayementHandler;
using Seldino.Application.Query.OrderService;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.Web.UI.Service_References.FanavaPaymentService;

namespace Seldino.Web.UI.Controllers
{
    /// <summary>
    /// Order Operation is just for system users
    /// </summary>
    //[Authorize]
    public class OrderController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IOrderQueryService _orderQueryService;

        public OrderController(ICommandBus commandBus, IOrderQueryService orderQueryService)
        {
            _commandBus = commandBus;
            _orderQueryService = orderQueryService;
        }

        [HttpPost]
        public ActionResult Create(CreateOrderCommand command)
        {
            if (!ModelState.IsValid) return JsonMessage("");
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ViewResult Invoice()
        {
            return View("Invoice");
        }

        [HttpPost]
        public JsonResult Delete(DeleteOrderCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        /// <summary>
        /// Canceling the order
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Cancel(CancelOrderCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        /// <summary>
        /// Pursuiting order 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OutputCache(Duration = 900, Location = OutputCacheLocation.Client, VaryByParam = "*")]
        public ActionResult Pursuit(Guid orderId)
        {
            var order = _orderQueryService.PursuitOrder(new OrderQueryRequest(orderId));
            return View("Pursuit", order);
        }

        [HttpPost]
        public ActionResult BankFinalAccept(SetOrderPaymentCommand command)
        {
            var fanava = new PaymentWebServiceClient();

            var sessionId = fanava.login(new loginRequest
            {
                username = "gh21369071",
                password = "88065088"
            });

            wsContext context = new wsContext
            {
                data = new wsContextEntry[1] { new wsContextEntry()
                    {
                        value = sessionId,
                        key = "SESSION_ID"
                    }
                }
            };

            string[] verifyRequest = { command.RefNum };

            var verifyStatus = fanava.verifyTransaction(context, verifyRequest);

            var verifyStatusMode = verifyStatus.Length > 0;

            if (verifyStatusMode == true)
            {
                var proformaId = long.Parse(command.ResNum);
                _commandBus.Send(command);

                //TickectService tickectService = new TickectService();
                //tickectService.UpdatePaymentedTicket(proformaId, result);

                //UssdTicketFullDetails fullTicket = GetFullTicket(proformaId);

                //fullTicket.Persons = tickectService.GetPersons(proformaId).Data;

                //RegisterTickets(fullTicket);
            }

            return View(command);
        }
    }
}