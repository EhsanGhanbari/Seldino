using Seldino.CrossCutting.Enums;

namespace Seldino.Domain.OrderAggregation.States
{
    public interface IOrderState
    {
        int Id { get; set; }
        OrderStatus Status { get; }
        bool CanAddProduct();
        void Submit(Order order);
    }
}