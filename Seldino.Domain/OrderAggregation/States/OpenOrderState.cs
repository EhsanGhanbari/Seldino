using Seldino.CrossCutting.Enums;
using Seldino.Infrastructure.Events;

namespace Seldino.Domain.OrderAggregation.States
{
    public class OpenOrderState : OrderState
    {
        public override OrderStatus Status
        {
            get { return OrderStatus.InProcess; }
        }

        public override bool CanAddProduct()
        {
            return true;
        }

        public override void Submit(Order order)
        {
            if (order.OrderHasBeenPaidFor())
                order.SetStateTo(OrderStates.Submitted);

            DomainEvents.Raise(new OrderSubmittedEvent() { Order = order });
        }
    }
}