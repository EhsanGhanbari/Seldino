namespace Seldino.Domain.OrderAggregation.States
{
    public class OrderStates
    {
        public static readonly IOrderState Open = new OpenOrderState() { Id = 1 };
        public static readonly IOrderState Submitted = new SubmittedOrderState() { Id = 2 };
    }
}