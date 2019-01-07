using System;
using Seldino.CrossCutting.Paging;

namespace Seldino.Application.Query.GiftDeskService
{
    public class GiftDesksQueryRequest : PagingQueryRequest
    {
        private readonly Guid _userId;

        public GiftDesksQueryRequest(Guid userId)
        {
            _userId = userId;
        }
    }
}
