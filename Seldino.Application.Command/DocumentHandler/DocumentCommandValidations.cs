using FluentValidation;

namespace Seldino.Application.Command.DocumentHandler
{
    internal class DocumentCommandValidation : AbstractValidator<DocumentCommand>
    {
        public DocumentCommandValidation()
        {
            RuleFor(p => p.SocialMedias).SetCollectionValidator(new SocialMediaCommandValidator());
        }
    }

    internal class SocialMediaCommandValidator : AbstractValidator<SocialMediaCommand>
    {
        internal SocialMediaCommandValidator()
        {
            RuleFor(r => r.Url).NotEmpty();
        }
    }
}
