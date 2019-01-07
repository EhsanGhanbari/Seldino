using System.Security.Cryptography.X509Certificates;
using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.NotificationAggregation
{
    public interface INotificationRepository : IRepositoryBase<Notification>
    {
        PagingQueryResponse<Notification> GetNotifications(PagingQueryRequest query);

        PagingQueryResponse<Notification> GetActiveNotifications(PagingQueryRequest query);
    }
}
