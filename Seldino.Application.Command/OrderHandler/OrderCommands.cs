using FluentValidation.Attributes;
using Seldino.Application.Command.CommandHandler;
using Seldino.Application.Command.PayementHandler;
using Seldino.CrossCutting.Enums;
using System;

namespace Seldino.Application.Command.OrderHandler
{
    public interface IOrderCommand : ICommand
    {
        ChargeAccountCommand CreatePayment { get; set; }

        OrderStatus OrderStatus { get; set; }

        Guid DeliveryId { get; set; }

        Guid BasketId { get; set; }

        Guid UserId { get; set; }
    }

    [Validator(typeof(OrderCommandValidation))]
    public class OrderCommand : IOrderCommand
    {
        public ChargeAccountCommand CreatePayment { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public Guid DeliveryId { get; set; }

        public Guid BasketId { get; set; }

        public Guid UserId { get; set; }
    }

    public class CreateOrderCommand : OrderCommand
    {
        public Guid[] ProductId { get; set; }
    }

    public class UpdateOrderCommand : OrderCommand
    {
        public Guid OrderId { get; set; }

        public Guid[] ProductId { get; set; }
    }

    public class CancelOrderCommand : ICommand
    {
        public Guid[] OrderIds { get; set; }
    }

    public class DeleteOrderCommand : ICommand
    {
        public Guid[] OrderIds { get; set; }
    }
}
