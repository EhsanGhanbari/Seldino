using System.Collections.Generic;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.DocumentService
{
    public class DocumentQueryResponse : QueryResponse
    {
        public DocumentDto Document { get; set; }
    }

    public class SocialMediaQueryResponse : QueryResponse
    {
       public  IList<SocialMediaOptionDto> SocialMediaOptions { get; set; }
    }


}
