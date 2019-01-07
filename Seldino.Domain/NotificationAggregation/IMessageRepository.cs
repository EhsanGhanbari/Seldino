using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.NotificationAggregation
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        PagingQueryResponse<Message> GetMessages(PagingQueryRequest query);

        PagingQueryResponse<Message> GetUnRepliedMessages(PagingQueryRequest query);

        PagingQueryResponse<Message> GetUnreadMessages(PagingQueryRequest query);
    }
}
