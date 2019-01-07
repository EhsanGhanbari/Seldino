using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.GiftDeskAggregation.Specifications
{
    public class RetrievableGiftDeskSpecification : Specification<GiftDesk>
    {
        public override bool IsSatisfiedBy(GiftDesk candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<GiftDesk, bool>> IsSatisfied()
        {
            return p => p.IsDeleted == false;
        }
    }
}
