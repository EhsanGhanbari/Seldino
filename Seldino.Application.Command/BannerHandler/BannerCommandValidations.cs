using FluentValidation;

namespace Seldino.Application.Command.BannerHandler
{

    internal class BannerCommandValidation : AbstractValidator<BannerCommand>
    {
        public BannerCommandValidation()
        {
            RuleFor(p => p.StartDate).NotEmpty().WithMessage(BannerValidationMessage.StartDateIsRequired);
            RuleFor(p => p.EndDate).NotEmpty().WithMessage(BannerValidationMessage.EndDateIsRequired);
            RuleFor(p => p.Fee).NotEmpty().WithMessage(BannerValidationMessage.BannerDateIsRequired);
        }
    }
}
