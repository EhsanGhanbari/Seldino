using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductMatchingInOwnerSpecification : Specification<Product>
    {
        private readonly Guid _userId;

        public ProductMatchingInOwnerSpecification(Guid userId)
        {
            _userId = userId;
        }

        public override bool IsSatisfiedBy(Product candidate)
        {
            return _userId != Guid.Empty || candidate.Users.Any(c => c.Id == _userId);
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            if (_userId != Guid.Empty)
            {
                return p => p.Users.Any(c => c.Id == _userId);
            }

            return p => true;
        }
    }
}