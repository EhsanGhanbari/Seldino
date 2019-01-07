using AutoMapper;
using Seldino.CrossCutting.Caching;
using Seldino.Domain.DiscountAggregation;
using System;
using Seldino.CrossCutting.Paging;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.DiscountService
{
    internal class DiscountQueryService : IDiscountQueryService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly ICacheManager _cacheManager;
        private readonly ILogger _logger;

        public DiscountQueryService(IDiscountRepository discountRepository, ICacheManager cacheManager, ILogger logger)
        {
            _discountRepository = discountRepository;
            _cacheManager = cacheManager;
            _logger = logger;
        }

        public DiscountQueryResponse GetDiscountById(DiscountQueryRequest request)
        {
            var response = new DiscountQueryResponse();

            try
            {
                var discount = _discountRepository.GetById(request.DiscountId);

                if (discount == null)
                {
                    response.Message = DiscountQueryMessage.DiscountDoesNotExist;
                    return response;
                }

                var result = Mapper.Map<Discount, DiscountDto>(discount);
                response.Discount = result;
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = QueryMessage.RetrievingFailed;
                _logger.Log(exception.Message);
            }

            return response;
        }

        public DiscountsQueryResponse GetAllDiscounts(DiscountQueryRequest request)
        {
            var response = new DiscountsQueryResponse();

            try
            {
                var discounts = _discountRepository.GetAllDiscounts(request, request.StoreId);

                if (discounts.Result == null)
                {
                    response.Message = DiscountQueryMessage.NoDiscountFound;
                    return response;
                }

                var result = Mapper.Map<PagingQueryResponse<Discount>, PagingQueryResponse<DiscountDto>>(discounts);
                response.Discounts = result;
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = QueryMessage.RetrievingFailed;
                _logger.Log(exception.Message);
            }

            return response;
        }

        public DiscountsQueryResponse GetAllActiveDiscounts(DiscountQueryRequest queryRequest)
        {
            var response = new DiscountsQueryResponse();

            try
            {
                var discounts = _discountRepository.GetAllAactiveDiscounts(queryRequest, queryRequest.DiscountId);

                if (discounts.Result == null)
                {
                    response.Message = DiscountQueryMessage.NoDiscountFound;
                    return response;
                }

                var result = Mapper.Map<PagingQueryResponse<Discount>, PagingQueryResponse<DiscountDto>>(discounts);
                response.Discounts = result;
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = QueryMessage.RetrievingFailed;
                _logger.Log(exception.Message);
            }

            return response;
        }

        public DiscountsQueryResponse GetAllInactiveDiscounts(DiscountQueryRequest queryRequest)
        {
            var response = new DiscountsQueryResponse();

            try
            {
                var discounts = _discountRepository.GetAllInactiveDiscounts(queryRequest, queryRequest.DiscountId);

                if (discounts.Result == null)
                {
                    response.Message = DiscountQueryMessage.NoDiscountFound;
                    return response;
                }

                var result = Mapper.Map<PagingQueryResponse<Discount>, PagingQueryResponse<DiscountDto>>(discounts);
                response.Discounts = result;
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = QueryMessage.RetrievingFailed;
                _logger.Log(exception.Message);
            }

            return response;
        }
    }
}
