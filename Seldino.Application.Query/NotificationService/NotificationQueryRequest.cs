using System;
using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.NotificationService
{


    public class NotificationQueryRequest : QueryRequest
    {
        public NotificationQueryRequest(Guid notificationId)
        {
            NotificationId = notificationId;
        }

        public Guid NotificationId { get; set; }
    }

    public class NotificationsQueryRequest : PagingQueryRequest
    {
        public NotificationsQueryRequest(string keyword)
        {
            Keyword = keyword;
        }

        public NotificationsQueryRequest(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

    public class MessageQueryRequest : QueryRequest
    {
        public Guid MessageId { get; set; }

        public MessageQueryRequest(Guid messageId)
        {
            MessageId = messageId;
        }
    }

    public class MessagesQueryRequest : PagingQueryRequest
    {
        public MessagesQueryRequest(string keyword)
        {
            Keyword = keyword;
        }

        public MessagesQueryRequest(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

    public class NewsletterQueryRequest : PagingQueryRequest
    {
        public NewsletterQueryRequest(string keyword)
        {
            Keyword = keyword;
        }

        public NewsletterQueryRequest(int pageIndex, int pageSize)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
