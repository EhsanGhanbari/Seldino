using System;
using System.Collections.Generic;
using Seldino.Domain.MembershipAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.LocationAggregation
{
    public class Location : EntityBase, IAggregateRoot
    {
        public string CountryName { get; set; }

        public Country Country { get; set; }

        public string StateName { get; set; }

        public State State { get; set; }

        public Guid AddressId { get; set; }

        public Address Address { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public ICollection<User> Users { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
