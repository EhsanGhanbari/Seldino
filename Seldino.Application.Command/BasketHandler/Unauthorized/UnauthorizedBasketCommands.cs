using System;
using Seldino.Application.Command.CommandHandler;

namespace Seldino.Application.Command.BasketHandler.Unauthorized
{
    public interface IUnauthorizedBasketCommand : ICommand
    {
        Guid[] ProductIds { get; set; }

        Guid CookieId { get; set; }

        int Quantity { get; set; }
    }

    public class UnauthorizedBasketCommand : IUnauthorizedBasketCommand
    {
        public Guid[] ProductIds { get; set; }

        public Guid CookieId { get; set; }

        public int Quantity { get; set; }
    }

    public class AddItemToUnauthorizedBasketCommand : UnauthorizedBasketCommand
    {

    }

    public class UpdateUnAuthorizedBasketQuantityCommand : ICommand
    {
        public Guid CookieId { get; set; }

        public int Quantity { get; set; }

        public Guid ProductId { get; set; }
    }

    public class RemoveItemFromUnauthorizedBasketCommand : ICommand
    {
        public Guid CookieId { get; set; }

        public Guid[] ProductIds { get; set; }
    }
}
