using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.PaymentAggregation.Specifications
{
    public class RetrievablePaymentSpecification : Specification<Payment>
    {
        public override bool IsSatisfiedBy(Payment candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<Payment, bool>> IsSatisfied()
        {
            return p => p.IsDeleted == false;
        }
    }
}