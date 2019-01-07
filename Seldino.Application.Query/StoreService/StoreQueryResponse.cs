using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.StoreService
{
    public class StoreQueryResponse : QueryResponse
    {
        public StoreDto Store { get; set; }
    }

    public class StoresQueryResponse : QueryResponse
    {
        public PagingQueryResponse<StoreDto> Stores { get; set; }
    }
}
