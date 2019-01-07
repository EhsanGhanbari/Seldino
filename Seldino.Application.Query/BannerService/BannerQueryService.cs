using AutoMapper;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.BannerAggregation;
using System;
using System.Collections;
using System.Collections.Generic;
using Seldino.CrossCutting.Caching;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.BannerService
{
    internal class BannerQueryService : IBannerQueryService
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly ICacheManager _cacheManager;
        private readonly ILogger _logger;

        public BannerQueryService(IBannerRepository bannerRepository, ICacheManager cacheManager, ILogger logger)
        {
            _bannerRepository = bannerRepository;
            _cacheManager = cacheManager;
            _logger = logger;
        }

        public BannerQueryResponse GetBannerDetailById(BannerQueryRequest request)
        {
            var response = new BannerQueryResponse();

            try
            {
                var banner = _bannerRepository.GetBannerById(request.BannerId);

                if (banner == null)
                {
                    response.Message = BannerQueryMessage.BannerDoesNotExist;
                    return response;
                }

                response.Banner = Mapper.Map<Banner, BannerDto>(banner);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Error(exception);
            }

            return response;
        }

        public BannersQueryResponse GetBanners(BannersQueryRequest request)
        {
            var response = new BannersQueryResponse();

            try
            {
                var banners = _bannerRepository.GetBanners(request);

                if (banners.Result == null)
                {
                    response.Message = BannerQueryMessage.NoBannerFound;
                    return response;
                }

                response.Banners = Mapper.Map<PagingQueryResponse<Banner>, PagingQueryResponse<BannerDto>>(banners);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Error(exception);
            }

            return response;
        }

        public BannersQueryResponse GetInactiveBanners(BannersQueryRequest request)
        {
            var response = new BannersQueryResponse();

            try
            {
                var banners = _bannerRepository.GetInactiveBanners(request);

                if (banners.Result == null)
                {
                    response.Message = BannerQueryMessage.NoBannerFound;
                    return response;
                }

                response.Banners = Mapper.Map<PagingQueryResponse<Banner>, PagingQueryResponse<BannerDto>>(banners);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Error(exception);
            }

            return response;
        }

        public BannersQueryResponse GetActiveBanners(BannersQueryRequest queryRequest)
        {
            var response = new BannersQueryResponse();

            try
            {
                var bannerDto = _cacheManager.Retrieve<PagingQueryResponse<BannerDto>>("ActiveBanners");

                if (bannerDto != null)
                {
                    response.Banners = bannerDto;
                    return response;
                }

                var banners = _bannerRepository.GetActiveBanners(queryRequest);

                if (banners.Result == null)
                {
                    response.Message = BannerQueryMessage.NoBannerFound;
                    return response;
                }

                bannerDto = Mapper.Map<PagingQueryResponse<Banner>, PagingQueryResponse<BannerDto>>(banners);
                _cacheManager.Store("ActiveBanners", bannerDto);
                return response;
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Error(exception);
            }

            return response;
        }

        public AdvBannersQueryQueryResponse GetAdvBanners(AdvBannersQueryQueryRequest request)
        {
            var response = new AdvBannersQueryQueryResponse();

            try
            {
                var banners= _bannerRepository.GetActiveAdvBanners(request.Count);
                response.Banners = Mapper.Map<IList<Banner>, IList<BannerDto>>(banners);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Error(exception);
            }

            return response;
        }


        public BannersQueryResponse GetUnConfirmedBanners(BannersQueryRequest queryRequest)
        {
            var response = new BannersQueryResponse();

            try
            {
                var banners = _bannerRepository.GetUnConfirmedBanners(queryRequest);

                if (banners.Result == null)
                {
                    response.Message = BannerQueryMessage.NoBannerFound;
                    return response;
                }

                response.Banners = Mapper.Map<PagingQueryResponse<Banner>, PagingQueryResponse<BannerDto>>(banners);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Error(exception);
            }

            return response;
        }
    }
}
