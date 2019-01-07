using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.StoreAggregation.Specifications
{
    public class RetrievableStoreSpecification : Specification<Store>
    {
        public string Keyword { get; set; }

        public RetrievableStoreSpecification()
        {
        }

        public RetrievableStoreSpecification(string keyword)
        {
            Keyword = keyword;
        }

        public override bool IsSatisfiedBy(Store candidate)
        {
            if (string.IsNullOrWhiteSpace(Keyword))
                return candidate.IsDeleted == false && candidate.IsInactive == false;
            return candidate.IsDeleted == false && candidate.IsInactive == false && candidate.Name.Contains(Keyword);
        }

        public override Expression<Func<Store, bool>> IsSatisfied()
        {
            if (string.IsNullOrWhiteSpace(Keyword))
                return s => (s.IsDeleted == false && s.IsInactive == false);
            return s => (s.IsDeleted == false && s.IsInactive == false && s.Name.Contains(Keyword));
        }
    }
}
