using System;
using System.Collections.Generic;
using AutoMapper;
using Seldino.Domain.LocationAggregation;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.LocationService
{
    internal class LocationQueryService : ILocationQueryService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILogger _logger;

        public LocationQueryService(ILocationRepository locationRepository, ILogger logger)
        {
            _locationRepository = locationRepository;
            _logger = logger;
        }

        public CountryQueryResponse GetCountries(CountryQueryRequest request)
        {
            var response = new CountryQueryResponse();

            try
            {
                var countries = _locationRepository.GetCountries();
                response.Countries = Mapper.Map<IList<Country>, IList<CountryDto>>(countries);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }
           
            return response;
        }

        public StatesQueryResponse GetStatesByCountry(StatesQueryRequest request)
        {
            var response = new StatesQueryResponse();

            try
            {
                var states = _locationRepository.GetStates(request.Country);

                if (states == null)
                {
                    response.Message = LocationQueryMessage.NoStateFound;
                    return response;
                }

                response.States = Mapper.Map<IList<State>, IList<StateDto>>(states);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }

            return response;
        }

        public AreasQueryResponse GetAreasByRegion(AreasQueryRequest request)
        {
            var response = new AreasQueryResponse();

            try
            {
                var areas = _locationRepository.GetAreasByRegion(request.Region);

                if (areas == null)
                {
                    response.Message = LocationQueryMessage.NoAreaFound;
                    return response;
                }

                response.Areas = Mapper.Map<IList<Area>, IList<AreaDto>>(areas);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }

            return response;
        }

        public RegionsQueryResponse GetRegions(RegionsQueryRequest request)
        {
            var response = new RegionsQueryResponse();

            try
            {
                var regions = _locationRepository.GetRegionsByCity(request.City);

                if (regions == null)
                {
                    response.Message = LocationQueryMessage.NoRegionFound;
                    return response;
                }

                response.Regions = Mapper.Map<IList<Region>, IList<RegionDto>>(regions);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }

            return response;
        }

        public RegionsQueryResponse GetSupportedRegionsByStore(RegionsQueryRequest request)
        {
            var response = new RegionsQueryResponse();

            try
            {
                var regions = _locationRepository.GetSupportedRegionsByStore(request.StoreId);

                if (regions == null)
                {
                    response.Message = LocationQueryMessage.NoSupportedRegionFound;
                    return response;
                }

                response.Regions = Mapper.Map<IList<Region>, IList<RegionDto>>(regions);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }

            return response;
        }

        public AreasQueryResponse GetSupportedAreasByStore(AreasQueryRequest request)
        {
            var response = new AreasQueryResponse();

            try
            {
                var regions = _locationRepository.GetSupportedAreasByStore(request.StoreId);

                if (regions == null)
                {
                    response.Message = LocationQueryMessage.NoSupportedAreaFound;
                    return response;
                }

                response.Areas = Mapper.Map<IList<Area>, IList<AreaDto>>(regions);
            }
            catch (Exception exception)
            {
                response.Failed = true;
                _logger.Log(exception);
            }

            return response;
        }
    }
}
