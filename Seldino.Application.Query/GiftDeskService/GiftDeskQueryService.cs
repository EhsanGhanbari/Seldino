using System;
using AutoMapper;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.GiftDeskAggregation;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.GiftDeskService
{
    internal class GiftDeskQueryService : IGiftDeskQueryService
    {
        private readonly IGiftDeskRepository _giftDeskRepository;
        private readonly ILogger _logger;

        public GiftDeskQueryService(IGiftDeskRepository giftDeskRepository, ILogger logger)
        {
            _giftDeskRepository = giftDeskRepository;
            _logger = logger;
        }

        public GiftDesksQueryResponse GetGiftDesks(GiftDesksQueryRequest request)
        {
            var response = new GiftDesksQueryResponse();

            try
            {
                var giftDesk = _giftDeskRepository.GetGiftDesks(request);

                if (giftDesk == null)
                {
                    response.Message = GiftDeskQueryMessage.NotFound;
                    return response;
                }

                response.GiftDesks = Mapper.Map<PagingQueryResponse<GiftDesk>, PagingQueryResponse<GiftDeskDto>>(giftDesk);

            }
            catch (Exception exception)
            {
                _logger.Log(exception);
            }

            return response;
        }
    }
}
