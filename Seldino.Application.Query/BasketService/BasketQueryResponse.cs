using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.BasketService
{
    public class BasketQueryResponse : QueryResponse
    {
        public BasketDto Basket { get; set; }
    }
}
