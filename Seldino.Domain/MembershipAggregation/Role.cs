using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.MembershipAggregation
{
    public class Role : ValueObjectBase
    {
        public bool IsDefault { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Operation> Operations { get; set; } 

        public ICollection<Permision> Permisions { get; set; } 

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}