using System;
using System.Collections.Generic;

namespace Seldino.Application.Query.LocationService
{
    public interface ILocationQueryService
    {
        CountryQueryResponse GetCountries(CountryQueryRequest request);

        StatesQueryResponse GetStatesByCountry(StatesQueryRequest country);

        AreasQueryResponse GetAreasByRegion(AreasQueryRequest request);

        RegionsQueryResponse GetRegions(RegionsQueryRequest request);

        RegionsQueryResponse GetSupportedRegionsByStore(RegionsQueryRequest request);

        AreasQueryResponse GetSupportedAreasByStore(AreasQueryRequest request);
    }
}
