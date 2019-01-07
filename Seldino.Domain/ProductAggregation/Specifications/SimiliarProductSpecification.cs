using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class SimiliarProductSpecification : Specification<Product>
    {
        public Guid ProductId { get; set; }

        public SimiliarProductSpecification(Guid productId)
        {
            ProductId = productId;
        }

        public override bool IsSatisfiedBy(Product candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            return c => c.Id != ProductId;
        }
    }
}
