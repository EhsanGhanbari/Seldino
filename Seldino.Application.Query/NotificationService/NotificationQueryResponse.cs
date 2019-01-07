using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.NotificationService
{
    public class NotificationQueryResponse : QueryResponse
    {
        public NotificationDto Notification { get; set; }
    }


    public class NotificationsQueryResponse : QueryResponse
    {
        public PagingQueryResponse<NotificationDto> Notifications { get; set; }
    }


    public class MessageQueryResponse : QueryResponse
    {
        public MessageDto NotificationMessage { get; set; }
    }

    public class MessagesQueryResponse : QueryResponse
    {
        public PagingQueryResponse<MessageDto> Messages { get; set; } 
    }

    public class NewsletterQueryResponse : QueryResponse
    {
        public PagingQueryResponse<NewsletterDto> NewsletterEmails { get; set; } 
    }

}
