using System;
using Seldino.CrossCutting.Queries;

namespace Seldino.CrossCutting.Paging
{
    public class PagingQueryRequest : QueryRequest
    {
        protected PagingQueryRequest()
        {
        }

        protected PagingQueryRequest(int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
        }

        protected PagingQueryRequest(int pageIndex, int pageSize, int count)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Count = count;
        }

        public int PageIndex { get; protected set; }

        public int PageSize { get; protected set; }

        public int Count { get; protected set; }
    }
}
