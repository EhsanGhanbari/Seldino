using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.LocationAggregation
{
    public class Country : ValueObjectBase
    {
        public string Name { get; set; }
        public ICollection<State> States { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
