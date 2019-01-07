using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Domain.LocationAggregation;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Repositories
{
    internal class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IList<Country> GetCountries()
        {
            return DataContext.Countries.ToList();
        }

        public IList<State> GetStates(string country)
        {
            return DataContext.States.ToList();
        }

        public IList<Region> GetRegionsByCity(string city)
        {
            return DataContext.Regions.Where(c => c.Cities.Any(d => d.Name == city)).ToList();
        }

        public IList<Area> GetAreasByRegion(string region)
        {
            return DataContext.Areas.Where(c => c.Regions.Any(d => d.Name == region)).ToList();
        }

        public IList<Region> GetSupportedRegionsByStore(Guid storeId)
        {
            return DataContext.Regions.Where(c => c.SupportedStores.Any(d => d.Id == storeId)).ToList();
        }

        public IList<Area> GetSupportedAreasByStore(Guid storeId)
        {
            return DataContext.Areas.Where(c => c.SupportedStores.Any(d => d.Id == storeId)).ToList();
        }
    }
}
