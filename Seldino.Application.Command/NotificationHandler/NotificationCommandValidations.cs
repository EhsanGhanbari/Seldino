using FluentValidation;

namespace Seldino.Application.Command.NotificationHandler
{
    #region Message
    internal class CreateMessageCommandValidation : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageCommandValidation()
        {
            RuleFor(m => m.Title).NotEmpty().WithMessage(NotificationValidationMessage.MesssageTitleIsEmpty)
                .Length(2, 100).WithMessage(NotificationValidationMessage.MesssageIsNotInRegularLenght);

            RuleFor(m => m.Name).Length(2, 30).WithMessage(NotificationValidationMessage.NameIsNotInRegularForm);

            RuleFor(m => m.Email).NotEmpty().WithMessage(NotificationValidationMessage.EmailIsRequired).
                EmailAddress().WithMessage(NotificationValidationMessage.EmailFormatIsIncorrect);

            RuleFor(m => m.Body).NotEmpty().WithMessage(NotificationValidationMessage.MessageBodyIsRquired)
                .Length(2, 500).WithMessage(NotificationValidationMessage.MessageBodyIsNotInReqularLenght);
        }
    }

    internal class CreateMessageResponseCommandValidation : AbstractValidator<CreateMessageResponseCommand>
    {
        public CreateMessageResponseCommandValidation()
        {
            RuleFor(m => m.Body).NotEmpty().WithMessage(NotificationValidationMessage.MessageBodyIsRquired)
              .Length(2, 500).WithMessage(NotificationValidationMessage.MessageBodyIsNotInReqularLenght);
        }
    }

    #endregion

    #region Newsletter

    internal class NewsletterCommandValidation : AbstractValidator<AddEmailToNewsletterCommand>
    {
        public NewsletterCommandValidation()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage(NotificationValidationMessage.EmailIsRequired)
              .EmailAddress().WithMessage(NotificationValidationMessage.EmailFormatIsIncorrect);
        }
    }

    #endregion
}
