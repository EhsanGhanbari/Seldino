using System;
using System.Collections.Generic;
using Seldino.Domain.StoreAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.LocationAggregation
{
    public class Area : ValueObjectBase
    {
        public string Name { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
        
        public virtual ICollection<Store> SupportedStores { get; set; } 

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}