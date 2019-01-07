using System;
using Seldino.Application.Command.CommandHandler;

namespace Seldino.Application.Command.BasketHandler
{
    public interface IBasketCommand : ICommand
    {
        Guid[] ProductIds { get; set; }

        Guid UserId { get; set; }

        int Quantity { get; set; }
    }

    public class BasketCommand : IBasketCommand
    {
        public Guid[] ProductIds { get; set; }

        public Guid UserId { get; set; }

        public int Quantity { get; set; }
    }

    public class AddItemToBasketCommand : BasketCommand
    {
    }

    public class UpdateBasketQuantityCommand : ICommand
    {
        public Guid UserId { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }
    }

    public class RemoveItemFromBasketCommand : ICommand
    {
        public Guid[] ProductIds { get; set; }

        public Guid UserId { get; set; }
    }

    public class TransferUnauthorizedBasketCommand : IBasketCommand
    {
        public Guid CookieId { get; set; }

        public Guid[] ProductIds { get; set; }

        public Guid UserId { get; set; }

        public int Quantity { get; set; }
    }
}

