using System.Web.Mvc;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.NotificationHandler;
using Seldino.Application.Query.NotificationService;
using Seldino.CrossCutting.Web.Controllers;

namespace Seldino.Web.UI.Controllers
{
    public class NotificationController : BaseController
    {
        #region Constructor

        private readonly ICommandBus _commandBus;
        private readonly INotificationQueryService _notificationQueryService;

        public NotificationController(ICommandBus commandBus, INotificationQueryService notificationQueryService)
        {
            _commandBus = commandBus;
            _notificationQueryService = notificationQueryService;
        }

        #endregion

        #region Notification
        public PartialViewResult Notifications()
        {
            var query = new MessagesQueryRequest(1, PageSize) { UserId = CurrentUser.Id };
            var messags = _notificationQueryService.GetMessages(query);
            return PartialView("Notifications", messags);
        }

        #endregion

        #region Messages 

        public PartialViewResult Messages()
        {
            var query = new MessagesQueryRequest(1, PageSize) { UserId = CurrentUser.Id };
            var messags = _notificationQueryService.GetMessages(query);
            return PartialView("Messages", messags);
        }

        #endregion

        #region Newsletter

        [ChildActionOnly]
        public PartialViewResult Newsletter()
        {
            return PartialView("Newsletter");
        }

        /// <summary>
        /// Adding an email by user to the new letter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddToNewsletter(AddEmailToNewsletterCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        /// <summary>
        /// removing an email by user from news letter list
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveFromNewsletter(RemoveEmailFromNewsLetterCommand command)
        {
            var result = _commandBus.Send(command);
            return JsonMessage(result);
        }

        #endregion
    }
}