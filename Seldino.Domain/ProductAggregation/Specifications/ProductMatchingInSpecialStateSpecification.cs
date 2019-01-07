using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductMatchingInSpecialStateSpecification : Specification<Product>
    {
        public override bool IsSatisfiedBy(Product candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<Product, bool>> IsSatisfied()
        {
            return p => (p.IsInactive == false && (p.ProductSpecialState.StartDate < DateTime.Now && p.ProductSpecialState.EndDate > DateTime.Now));
        }
    }
}
