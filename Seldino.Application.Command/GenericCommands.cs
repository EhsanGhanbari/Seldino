using System;
using System.Web;

namespace Seldino.Application.Command
{
    public class PictureCommand
    {
        public Guid PictureId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string FullPath => Address + Name;

        public HttpPostedFileBase HttpPostedFileBase { get; set; }
    }

    public class LocationCommand
    {
        public CountryCommand Country { get; set; }
        public StateCommand State { get; set; }
        public AddressCommand Address { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }

    public class CountryCommand
    {
        public string Name { get; set; }
    }

    public class StateCommand
    {
        public string Name { get; set; }
    }

    public class AddressCommand
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
