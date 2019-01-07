using System;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.DocumentService
{
    public class DocumentQueryRequest : QueryRequest
    {
        public Guid StoreId { get; set; } 

        public Guid DocumentId { get; set; }
    }

    public class SocialMediaQueryRequest : QueryRequest
    {
        
    }
}
