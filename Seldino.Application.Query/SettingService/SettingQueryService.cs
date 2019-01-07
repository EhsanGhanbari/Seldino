using System;
using AutoMapper;
using Seldino.CrossCutting.Caching;
using Seldino.Domain.SettingAggregation;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.SettingService
{
    internal class SettingQueryService : ISettingQueryService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly ICacheManager _cacheManager;
        private readonly ILogger _logger;

        public SettingQueryService(
            ISettingRepository settingRepository, 
            ICacheManager cacheManager,
            ILogger logger)
        {
            _settingRepository = settingRepository;
            _cacheManager = cacheManager;
            _logger = logger;
        }

        public GetSettingQueryResponse GetCachedSetting(GetSettingQueryRequest request)
        {
            var response = new GetSettingQueryResponse();

            try
            {
                var settingDto = _cacheManager.Retrieve<SettingDto>("DefaultSetting");

                if (settingDto != null)
                {
                    response.Setting = settingDto;
                }

                var setting = _settingRepository.GetDefault();

                settingDto = Mapper.Map<Setting, SettingDto>(setting);
                response.Setting = settingDto;
                _cacheManager.Store("DefaultSetting", settingDto);
            }
            catch (Exception exception)
            {
                _logger.Error(exception);
                response.Failed = true;
            }

            return response;
        }
    }
}
