using FluentValidation;

namespace Seldino.Application.Command.PayementHandler
{
    internal class PaymentCommandValidation : AbstractValidator<ChargeAccountCommand>
    {
        public PaymentCommandValidation()
        {
        }
    }
}
