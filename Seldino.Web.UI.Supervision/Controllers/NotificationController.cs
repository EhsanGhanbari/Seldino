using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.NotificationHandler;
using Seldino.Application.Query.NotificationService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly INotificationQueryService _messageQueryService;

        public NotificationController(ICommandBus commandBus, INotificationQueryService messageQueryService)
        {
            _commandBus = commandBus;
            _messageQueryService = messageQueryService;
        }

        /// <summary>
        /// Lists all notification descending 
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int pageIndex, int pageSize)
        {
            var query = new MessagesQueryRequest(pageIndex, pageSize);
            var messages = _messageQueryService.GetMessages(query);
            return View("List", messages);
        }

        public ActionResult Unread(int pageIndex, int pageSize)
        {
            var query = new MessagesQueryRequest(pageIndex, pageSize);
            var messages = _messageQueryService.GetUnreadMessages(query);
            return View("Unread", messages);
        }

        public ActionResult UnReplied(int pageIndex, int pageSize)
        {
            var query = new MessagesQueryRequest(pageIndex, pageSize);
            var messages = _messageQueryService.GetUnRepliedMessages(query);
            return View("UnReplied", messages);
        }

        [HttpPost]
        public JsonResult MarkAsRead(MarkMessageAsReadCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [HttpPost]
        public ActionResult Reply(CreateMessageResponseCommand command)
        {
            if (!ModelState.IsValid) return View();
            var result = _commandBus.Send(command);
            return View(result);
        }
    }
}