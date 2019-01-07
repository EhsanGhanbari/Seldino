using FluentValidation;

namespace Seldino.Application.Command.DiscountHandler
{
    public class DiscountCommandValidation : AbstractValidator<CreateDiscountCommand>
    {
        public DiscountCommandValidation()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage(DiscountValidationMessage.DiscountTemplateNameIsRequired);
        }
    }
}
