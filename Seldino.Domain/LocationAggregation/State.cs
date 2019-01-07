using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.LocationAggregation
{
    public class State : ValueObjectBase
    {
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; } 

        public ICollection<Country> Countries { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
