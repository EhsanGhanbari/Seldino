using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.MembershipAggregation
{
    public class Permision : EntityBase
    {
        public bool Access { get; set; }

        public Guid OperationId { get; set; }

        public virtual Operation Operation { get; set; }

        public ICollection<Role> Role { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
