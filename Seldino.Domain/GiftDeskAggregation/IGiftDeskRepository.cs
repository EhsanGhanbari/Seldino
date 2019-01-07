using System.Collections.Generic;
using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.GiftDeskAggregation
{
    public interface IGiftDeskRepository : IRepositoryBase<GiftDesk>
    {
        PagingQueryResponse<GiftDesk> GetGiftDesks(PagingQueryRequest query);
    }
}
