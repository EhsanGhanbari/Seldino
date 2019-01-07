namespace Seldino.Application.Query.BasketService
{
    public interface IBasketQueryService
    {
        BasketQueryResponse GetBasketItems(BasketQueryRequest queryRequest);
    }
}
