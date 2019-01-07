using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.LocationAggregation
{
    public interface ILocationRepository : IRepositoryBase<Location>
    {
        IList<Country> GetCountries();

        IList<State> GetStates(string country);

        IList<Region> GetRegionsByCity(string city);

        IList<Area> GetAreasByRegion(string region);

        IList<Region> GetSupportedRegionsByStore(Guid storeId);
    
        IList<Area> GetSupportedAreasByStore(Guid storeId);
    }
}
