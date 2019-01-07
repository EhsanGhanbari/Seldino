using Seldino.Infrastructure.Events;

namespace Seldino.Domain.OrderAggregation
{
    public class OrderSubmittedEvent : IDomainEvent
    {
        public Order Order { get; set; }
    }
}
