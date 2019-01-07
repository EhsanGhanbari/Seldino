using System;
using Seldino.CrossCutting.Queries;

namespace Seldino.Application.Query.LocationService
{
    public class LocationQueryRequest
    {
    }

    public class CountryQueryRequest : QueryRequest
    {
    }

    public class StatesQueryRequest : QueryRequest
    {
        public string Country { get; set; }
    }

    public class RegionsQueryRequest : QueryRequest
    {
        public Guid StoreId { get; set; }

        public string City { get; set; }
    }

    public class AreasQueryRequest : QueryRequest
    {
        public Guid StoreId { get; set; }

        public string Region { get; set; }
    }

    public class CitiesQueryRequest : QueryRequest
    {
        
    }
}
