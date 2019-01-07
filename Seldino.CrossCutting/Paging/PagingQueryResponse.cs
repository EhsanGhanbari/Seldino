using System;
using System.Collections.Generic;
using Seldino.CrossCutting.Queries;

namespace Seldino.CrossCutting.Paging
{
    public class PagingQueryResponse<TEntity> : QueryResponse
    {
        public IList<TEntity> Result { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public bool HasMoreResults => TotalCount > (TotalPages * PageSize);
    }
}
