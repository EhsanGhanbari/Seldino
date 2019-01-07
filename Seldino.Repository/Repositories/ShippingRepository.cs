using Seldino.Domain.ShippingAggregation;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Repositories
{
    internal class DeliverOptionRepository : RepositoryBase<DeliveryOption>, IDeliveryOptionRepository
    {
        public DeliverOptionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
