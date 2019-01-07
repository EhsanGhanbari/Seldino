using System.Collections.Generic;

namespace Seldino.Application.Query.LocationService
{
    public class LocationDto
    {
        public AddressDto Address { get; set; }

        public CountryDto Country { get; set; }

        public StateDto State { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }

    public class AddressDto
    {
        public string AddressLine { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }
    }

    public class CountryDto
    {
        public string Name { get; set; }

        public List<StateDto> States { get; set; }
    }

    public class StateDto
    {
        public string Name { get; set; }
    }

    public class AreaDto
    {
        public string Name { get; set; }
    }

    public class RegionDto
    {
        public string Name { get; set; }

        public IList<AreaDto> Areas { get; set; } 
    }
}
