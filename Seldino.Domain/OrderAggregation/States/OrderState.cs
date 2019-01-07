using Seldino.CrossCutting.Enums;

namespace Seldino.Domain.OrderAggregation.States
{
    public abstract class OrderState : IOrderState
    {
        public virtual int Id { get; set; }

        public abstract OrderStatus Status { get; }

        public abstract bool CanAddProduct();

        public abstract void Submit(Order order);
    }
}
