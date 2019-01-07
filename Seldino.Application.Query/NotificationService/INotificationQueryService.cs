
namespace Seldino.Application.Query.NotificationService
{
    public interface INotificationQueryService
    {
        #region Systematic

        NotificationQueryResponse GetNotification(NotificationQueryRequest request);

        NotificationsQueryResponse GetNotifications(NotificationsQueryRequest request);

        NotificationsQueryResponse GetActiveNotifications(NotificationsQueryRequest request);
        #endregion

        #region Message

        MessageQueryResponse GetMessageById(MessageQueryRequest request);

        MessagesQueryResponse GetMessages(MessagesQueryRequest request);

        MessagesQueryResponse GetUnRepliedMessages(MessagesQueryRequest request);

        MessagesQueryResponse GetUnreadMessages(MessagesQueryRequest request);

        #endregion

        #region Newsletter

        NewsletterQueryResponse GetNewsletteEmails(NewsletterQueryRequest request);

        #endregion
    }
}
