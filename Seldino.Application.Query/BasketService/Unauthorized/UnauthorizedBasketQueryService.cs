using System;
using AutoMapper;
using Seldino.Domain.BasketAggregation.Unauthorized;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.BasketService.Unauthorized
{
    public class UnauthorizedBasketQueryService : IUnauthorizedBasketQueryService
    {
        private readonly IUnauthorizedBasketRepository _unauthorizedBasketRepository;
        private readonly ILogger _logger;

        public UnauthorizedBasketQueryService(IUnauthorizedBasketRepository unauthorizedBasketRepository, ILogger logger)
        {
            _unauthorizedBasketRepository = unauthorizedBasketRepository;
            _logger = logger;
        }


        public BasketQueryResponse GetBasketItems(BasketQueryRequest queryRequest)
        {
            var response = new BasketQueryResponse();

            try
            {
                var baskets = _unauthorizedBasketRepository.GetBasketItems(queryRequest, queryRequest.CookieId);

                if (baskets == null)
                {
                    response.Message = BasketQueryMessages.BasketIsEmpty;
                    return response;
                }

                response.Basket = Mapper.Map<UnauthorizedBasket, BasketDto>(baskets);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return response;
        }
    }
}
