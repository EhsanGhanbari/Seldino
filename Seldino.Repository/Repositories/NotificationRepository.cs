using System.Data.Entity;
using System.Linq;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.NotificationAggregation;
using Seldino.Domain.NotificationAggregation.Specificaions;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Repositories
{
    internal class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public PagingQueryResponse<Notification> GetNotifications(PagingQueryRequest query)
        {
            var specification = new RetrievableNotificationSpecification();
            var totalCount = ReadOnlyDataContext.Notifications.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Notification>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Notifications
                    .Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Notification> GetActiveNotifications(PagingQueryRequest query)
        {
            var specification = new RetrievableNotificationSpecification().And(new ActiveNotificationSpecification());
            var totalCount = ReadOnlyDataContext.Notifications.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Notification>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Notifications
                    .Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }
    }

    internal class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public PagingQueryResponse<Message> GetMessages(PagingQueryRequest query)
        {
            var specification = new RetrievableMessageSpecification();
            var totalCount = ReadOnlyDataContext.Messages.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Message>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Messages
                    .Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Message> GetUnRepliedMessages(PagingQueryRequest query)
        {
            var specification = new RetrievableMessageSpecification().And(new UnRepliedMessageSpecification(query.UserId));
            var totalCount = ReadOnlyDataContext.Messages.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Message>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Messages
                    .Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }

        public PagingQueryResponse<Message> GetUnreadMessages(PagingQueryRequest query)
        {
            var specification = new RetrievableMessageSpecification().And(new UnReadMessageSpecification(query.UserId));
            var totalCount = ReadOnlyDataContext.Messages.Where(specification.IsSatisfied()).AsNoTracking().Count();

            var result = new PagingQueryResponse<Message>
            {
                PageSize = query.PageSize,
                CurrentPage = query.PageIndex,
                TotalCount = totalCount,
                Result = DataContext.Messages
                    .Where(specification.IsSatisfied())
                    .OrderByDescending(c => c.CreationDate)
                    .Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize).ToList()
            };

            return result;
        }
    }

    internal class MessageResponseRepository : RepositoryBase<MessageResponse>, IMessageResponseRepository
    {
        public MessageResponseRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    internal class NewsletterRepository : RepositoryBase<Newsletter>, INewsletterRepository
    {
        public NewsletterRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
