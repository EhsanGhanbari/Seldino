using System.Collections.Generic;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.LocationService
{
    public class LocationQueryResponse : QueryResponse
    {
        public LocationDto Location { get; set; }
    }

    public class AreasQueryResponse : QueryResponse
    {
        public IList<AreaDto> Areas { get; set; }
    }

    public class RegionsQueryResponse : QueryResponse
    {
        public IList<RegionDto> Regions { get; set; }
    }

    public class StatesQueryResponse : QueryResponse
    {
        public IList<StateDto> States { get; set; }
    }

    public class CountryQueryResponse : QueryResponse
    {
        public IList<CountryDto> Countries { get; set; } 
    }
}
