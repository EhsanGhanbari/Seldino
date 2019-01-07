using FluentValidation;

namespace Seldino.Application.Command.OrderHandler
{
    internal class OrderCommandValidation : AbstractValidator<OrderCommand>
    {
        public OrderCommandValidation()
        {
            
        }
    }
}
