using System;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.NotificationHandler;
using Seldino.Application.Query.NotificationService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Supervision.Controllers
{
    [Authorize]
    public class ContactController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly INotificationQueryService _messageQueryService;

        public ContactController(ICommandBus commandBus, INotificationQueryService messageQueryService)
        {
            _commandBus = commandBus;
            _messageQueryService = messageQueryService;
        }

        /// <summary>
        /// Lists all notification descending 
        /// </summary>
        /// <returns></returns>
        public ActionResult Messages(int pageIndex, int pageSize)
        {
            var query = new MessagesQueryRequest(pageIndex, pageSize) { UserId = CurrentUser.Id };
            var messages = _messageQueryService.GetMessages(query);
            return View("Messages", messages);
        }

        public ActionResult Unreads(int pageIndex, int pageSize)
        {
            var query = new MessagesQueryRequest(pageIndex, pageSize) { UserId = CurrentUser.Id };
            var unreadMessages = _messageQueryService.GetUnreadMessages(query);
            return View("Unreads", unreadMessages);
        }

        [HttpPost]
        public JsonResult MarkAsRead(MarkMessageAsReadCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ActionResult Reply(Guid messageId)
        {
            var message = _messageQueryService.GetMessageById(new MessageQueryRequest(messageId));
            return View("Reply", message);
        }

        [HttpPost]
        public ActionResult Reply(CreateMessageResponseCommand command)
        {
            if (!ModelState.IsValid) return View();
            var result = _commandBus.Send(command);
            return View(result);
        }

        [HttpPost]
        public JsonResult DeleteMessage(DeleteMessageCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }
    }
}