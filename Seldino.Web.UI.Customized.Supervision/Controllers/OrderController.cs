using System;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Query.OrderService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IOrderQueryService _orderQueryService;

        public OrderController(ICommandBus commandBus, IOrderQueryService orderQueryService)
        {
            _commandBus = commandBus;
            _orderQueryService = orderQueryService;
        }

        public ActionResult List(int pageIndex, int pageSize)
        {
            var query = new OrdersQueryRequest(pageIndex, pageSize);
            var orders = _orderQueryService.GetOrders(query);
            return View("List", orders);
        }

        /// <summary>
        /// filter orders by pending
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Pending(int pageIndex, int pageSize)
        {
            var query = new OrdersQueryRequest(pageIndex, pageSize);
            var orders = _orderQueryService.GetPendingOrders(query);
            return View("Pending", orders);
        }

        /// <summary>
        /// Orders which have been completed the process 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Completed(int pageIndex, int pageSize)
        {
            var query = new OrdersQueryRequest(pageIndex, pageSize);
            var orders = _orderQueryService.GetCompletedOrders(query);
            return View("Completed", orders);
        }

        public ActionResult Detail(Guid id)
        {
            var order = _orderQueryService.GetOrderById(new OrderQueryRequest(id));
            return View("Detail", order);
        }
    }
}