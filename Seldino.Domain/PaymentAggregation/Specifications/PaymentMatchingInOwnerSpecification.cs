using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.PaymentAggregation.Specifications
{
    public class PaymentMatchingInOwnerSpecification : Specification<Payment>
    {
        private readonly Guid _userId;

        public PaymentMatchingInOwnerSpecification(Guid userId)
        {
            _userId = userId;
        }

        public override bool IsSatisfiedBy(Payment candidate)
        {
            return _userId != Guid.Empty || candidate.Users.Any(c => c.Id == _userId);
        }

        public override Expression<Func<Payment, bool>> IsSatisfied()
        {
            if (_userId != Guid.Empty)
            {
                return p => p.Users.Any(c => c.Id == _userId);
            }

            return p => true;
        }
    }
}
