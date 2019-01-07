using System;
using Seldino.CrossCutting.Paging;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.StoreService
{
    public class StoreQueryRequest : QueryRequest
    {
        public StoreQueryRequest(Guid storeId)
        {
            StoreId = storeId;
        }

        public Guid StoreId { get; set; }
    }

    public class StoresQueryRequest : PagingQueryRequest
    {
        public StoresQueryRequest(Guid userId)
        {
            UserId = userId;
        }

        public StoresQueryRequest(string keyword)
        {
            Keyword = keyword;
        }

        public StoresQueryRequest(int pageIndex, int pageSize)
           : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public StoresQueryRequest(int pageIndex, int pageSize, Guid userId)
            : base(pageIndex, pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            UserId = userId;
        }
    }
}
