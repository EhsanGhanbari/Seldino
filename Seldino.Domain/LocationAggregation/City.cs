using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.LocationAggregation
{
    public class City : ValueObjectBase
    {
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; }

        public virtual ICollection<Region> Regions { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
