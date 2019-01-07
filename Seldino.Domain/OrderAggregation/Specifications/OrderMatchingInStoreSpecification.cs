using System;
using System.Linq.Expressions;
using Seldino.Infrastructure.Specification;

namespace Seldino.Domain.OrderAggregation.Specifications
{
    public class OrderMatchingInStoreSpecification : Specification<Order>
    {
        private readonly Guid _storId;

        public OrderMatchingInStoreSpecification(Guid storeId)
        {
            _storId = storeId;
        }

        public override bool IsSatisfiedBy(Order candidate)
        {
            throw new NotImplementedException();
        }

        public override Expression<Func<Order, bool>> IsSatisfied()
        {
            if (_storId != Guid.Empty)
            {
                return p => p.User.Id == _storId;
                //ToDo Matcing in store, relation between store and order!
            }

            return p => true;
        }
    }
}
