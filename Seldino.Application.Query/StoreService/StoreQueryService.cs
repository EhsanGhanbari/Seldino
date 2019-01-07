using System;
using System.Linq;
using AutoMapper;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.StoreAggregation;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.StoreService
{
    internal class StoreQueryService : IStoreQueryService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ILogger _logger;

        public StoreQueryService(IStoreRepository storeRepository, ILogger logger)
        {
            _storeRepository = storeRepository;
            _logger = logger;
        }

        public StoreQueryResponse GetStoreById(StoreQueryRequest request)
        {
            var response = new StoreQueryResponse();

            try
            {
                var store = _storeRepository.GetById(request.StoreId);

                if (store == null)
                {
                    response.Message = StoreQueryMessage.StoreCouldNotFound;
                    return response;
                }

                response.Store = Mapper.Map<Store, StoreDto>(store);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = StoreQueryMessage.LoadingStoreFaild;
                _logger.Error(exception.Message);
            }

            return response;
        }

        public StoreQueryResponse GetStoreDetailById(StoreQueryRequest request)
        {
            var response = new StoreQueryResponse();

            try
            {
                var store = _storeRepository.GetStoreDetailById(request.StoreId);

                if (store == null)
                {
                    response.Message = StoreQueryMessage.StoreCouldNotFound;
                    return response;
                }

                response.Store = Mapper.Map<Store, StoreDto>(store);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = StoreQueryMessage.LoadingStoreFaild;
                _logger.Error(exception.Message);
            }

            return response;
        }

        public StoresQueryResponse GetStores(StoresQueryRequest queryRequest)
        {
            var response = new StoresQueryResponse();

            try
            {
                var stores = _storeRepository.GetStores(queryRequest);

                if (!stores.Result.Any())
                {
                    response.Message = StoreQueryMessage.NoStoreFound;
                }

                response.Stores = Mapper.Map<PagingQueryResponse<Store>, PagingQueryResponse<StoreDto>>(stores);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = StoreQueryMessage.LoadingStoresFaild;
                _logger.Error(exception.Message);
            }

            return response;
        }

        public StoresQueryResponse GetInactiveStores(StoresQueryRequest queryRequest)
        {
            var response = new StoresQueryResponse();

            try
            {
                var stores = _storeRepository.GetInactiveStores(queryRequest);

                if (stores == null)
                {
                    response.Message = StoreQueryMessage.NoStoreFound;
                    return response;
                }

                response.Stores = Mapper.Map<PagingQueryResponse<Store>, PagingQueryResponse<StoreDto>>(stores);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = StoreQueryMessage.LoadingStoresFaild;
                _logger.Error(exception.Message);
            }

            return response;
        }

        public StoresQueryResponse GetBestSellingStores(StoresQueryRequest queryRequest)
        {
            var response = new StoresQueryResponse();

            try
            {
                var stores = _storeRepository.GetBestSellingStores(queryRequest);

                if (stores == null)
                {
                    response.Message = StoreQueryMessage.NoStoreFound;
                    return response;
                }

                response.Stores = Mapper.Map<PagingQueryResponse<Store>, PagingQueryResponse<StoreDto>>(stores);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = StoreQueryMessage.LoadingStoresFaild;
                _logger.Error(exception.Message);
            }

            return response;
        }

        public StoresQueryResponse GetDiscountedStores(StoresQueryRequest queryRequest)
        {

            var response = new StoresQueryResponse();

            try
            {
                var stores = _storeRepository.GetDiscountedStores(queryRequest);

                if (stores == null)
                {
                    response.Message = StoreQueryMessage.NoStoreFound;
                    return response;
                }

                response.Stores = Mapper.Map<PagingQueryResponse<Store>, PagingQueryResponse<StoreDto>>(stores);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                response.Message = StoreQueryMessage.LoadingStoresFaild;
                _logger.Error(exception.Message);
            }

            return response;
        }
    }
}
