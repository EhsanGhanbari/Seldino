using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductMatchingInStoreSpecification : Specification<Product>
    {
        private readonly Guid _storeId;

        public ProductMatchingInStoreSpecification(Guid storeId)
        {
            _storeId = storeId;
        }

        public override bool IsSatisfiedBy(Product candidate)
        {
            return candidate.Stores.Any(c => c.Id == _storeId);
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            return p => p.Stores.Any(c => c.Id == _storeId);
        }
    }
}
