using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.MembershipAggregation
{
    public class Operation : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Role> Roles { get; set; } 

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
