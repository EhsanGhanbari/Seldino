using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.StoreAggregation
{
    public class StorePicture : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Store> Stores { get; set; } 

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
