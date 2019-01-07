using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.GiftDeskService
{
    public class GiftDesksQueryResponse : QueryResponse
    {
        public PagingQueryResponse<GiftDeskDto> GiftDesks { get; set; }
    }
}
