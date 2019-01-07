using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.NotificationHandler;
using Seldino.Application.Query.NotificationService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Areas.Management.Controllers
{
    public class NotificationController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly INotificationQueryService _notificationQueryService;

        public NotificationController(ICommandBus commandBus, INotificationQueryService notificationQueryService)
        {
            _commandBus = commandBus;
            _notificationQueryService = notificationQueryService;
        }

        /// <summary>
        /// Returns all message created in the stytem
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int pageIndex)
        {
            var query = new MessagesQueryRequest(pageIndex, PageSize) { UserId = CurrentUser.Id };
            var messags = _notificationQueryService.GetMessages(query);
            return View("List", messags);
        }

        /// <summary>
        /// returns all uncread messages
        /// </summary>
        /// <returns></returns>
        public ActionResult Unread(int pageIndex)
        {
            var query = new MessagesQueryRequest(pageIndex, PageSize) { UserId = CurrentUser.Id };
            var messages = _notificationQueryService.GetUnreadMessages(query);
            return View("Unread", messages);
        }

        /// <summary>
        /// Returns all unreplied message 
        /// </summary>
        /// <returns></returns>
        public ActionResult UnReplied(int pageIndex)
        {
            var query = new MessagesQueryRequest(pageIndex, PageSize) { UserId = CurrentUser.Id };
            var message = _notificationQueryService.GetUnRepliedMessages(query);
            return View("UnReplied", message);
        }

        /// <summary>
        /// Reply to the conact
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Reply(CreateMessageResponseCommand command)
        {
            if (!ModelState.IsValid) return View();
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        /// <summary>
        /// removes a message from system
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(DeleteMessageCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }
    }
}