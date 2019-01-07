using System;
using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.NotificationHandler;
using Seldino.Application.Query.NotificationService;
using Seldino.CrossCutting.Web.Controllers;
using Seldino.CrossCutting.Web.Extensions;

namespace Seldino.Web.UI.Supervision.Controllers
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

        #region Notification

        /// <summary>
        /// System notifications
        /// </summary>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        public ActionResult Notification(Guid  notificationId)
        {
            var request = new NotificationQueryRequest(notificationId);
            var response = _notificationQueryService.GetNotification(request);
            return View("Notification", response);
        }

        /// <summary>
        /// System notifications
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult Notifications(int pageIndex)
        {
            var request = new NotificationsQueryRequest(pageIndex, PageSize);
            var response = _notificationQueryService.GetNotifications(request);
            return View("Notifications", response);
        }

        /// <summary>
        /// Create system notification
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(CreateNotificationCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = _commandBus.Send(command);
                return JsonMessage(result);
            }

            return View("Create");
        }

        public ActionResult Edit(Guid notificationId)
        {
            var response = _notificationQueryService.GetNotification(new NotificationQueryRequest(notificationId));
            var command = response.Notification.ToCommand();
            return View("Edit", command);
        }

        [HttpPost]
        public ActionResult Edit(EditNotificationCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = _commandBus.Send(command);
                return JsonMessage(result);
            }

            return View("Edit");
        }

        [HttpPost]
        public JsonResult DeleteNotification(DeleteMessageCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Messages

        /// <summary>
        /// Lists all user notification(message)
        /// </summary>
        /// <returns></returns> 
        public ActionResult Messages(int pageIndex)
        {
            var query = new MessagesQueryRequest(pageIndex, PageSize) { UserId = CurrentUser.Id };
            var response = _notificationQueryService.GetMessages(query);
            return View("Messages", response);
        }

        public ActionResult UnreadMessages(int pageIndex)
        {
            var query = new MessagesQueryRequest(pageIndex, PageSize) { UserId = CurrentUser.Id };
            var response = _notificationQueryService.GetUnreadMessages(query);
            return View("UnreadMessages", response);
        }

        [HttpPost]
        public JsonResult MarkAsRead(MarkMessageAsReadCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        public ActionResult ReplyMessage(Guid messageId)
        {
            var response = _notificationQueryService.GetMessageById(new MessageQueryRequest(messageId));
            return View("ReplyMessage", response);
        }

        [HttpPost]
        public ActionResult ReplyMessage(CreateMessageResponseCommand command)
        {
            if (!ModelState.IsValid) return View();
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        [HttpPost]
        public JsonResult DeleteMessage(DeleteMessageCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion

        #region Newsletter

        public ActionResult NewsletterEmails(int pageIndex)
        {
            var request = new NewsletterQueryRequest(pageIndex, PageSize);
            var response = _notificationQueryService.GetNewsletteEmails(request);
            return View("NewsletterEmails", response);
        }

        #endregion
    }
}