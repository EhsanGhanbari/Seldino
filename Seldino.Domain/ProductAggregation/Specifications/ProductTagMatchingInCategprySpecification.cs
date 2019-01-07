using System;
using System.Linq;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.ProductAggregation.Specifications
{
    public class ProductTagMatchingInCategprySpecification : Specification<ProductTag>
    {
        public string Category { get; set; }

        public string Keyword { get; set; }

        public ProductTagMatchingInCategprySpecification(string category, string keyword)
        {
            Category = category;
            Keyword = keyword;
        }

        public override bool IsSatisfiedBy(ProductTag candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<ProductTag, bool>> IsSatisfied()
        {
            if (Category == null)
            {
                return p => p.IsDeleted == false;
            }
            if (string.IsNullOrWhiteSpace(Keyword))
            {
                return p => p.ProductCategories.Any(c => c.IsDeleted == false && c.Name == Category);
            }

            return p => p.ProductCategories.Any(c => c.IsDeleted == false && c.Name == Category && p.Name.Contains(Keyword));
        }
    }
}