using System;
using AutoMapper;
using Seldino.Domain.BasketAggregation;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.BasketService
{
    internal class BasketQueryService : IBasketQueryService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ILogger _logger;

        public BasketQueryService(IBasketRepository basketRepository, ILogger logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }

        public BasketQueryResponse GetBasketItems(BasketQueryRequest queryRequest)
        {
            var response = new BasketQueryResponse();

            try
            {
                var baskets = _basketRepository.GetBasketItems(queryRequest);

                if (baskets == null)
                {
                    response.Message = BasketQueryMessages.BasketIsEmpty;
                    return response;
                }

                response.Basket = Mapper.Map<Basket, BasketDto>(baskets);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return response;
        }
    }
}
