namespace Seldino.Application.Query.BasketService.Unauthorized
{
    public interface IUnauthorizedBasketQueryService
    {
        BasketQueryResponse GetBasketItems(BasketQueryRequest queryRequest);
    }
}
