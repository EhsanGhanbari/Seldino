using Seldino.Application.Command.CommandHandler;
using System;
using Seldino.Domain.NotificationAggregation;

namespace Seldino.Application.Command.NotificationHandler
{
    internal partial class NotificationCommandHandler :
        ICommandHandler<AddEmailToNewsletterCommand>,
        ICommandHandler<RemoveEmailFromNewsLetterCommand>
    {
        public ICommandResult Execute(AddEmailToNewsletterCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var newsletter = new Newsletter();
                AddToNewsletter(command, newsletter);
                _newsletterRepository.Add(newsletter);
                _unitOfWork.Commit();
                return new SuccessResult(NotificationCommandMessage.EmailAddedToNewslettersuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(NotificationCommandMessage.AddingEmailToNewsletterFaild);
            }
        }

        public ICommandResult Execute(RemoveEmailFromNewsLetterCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var newsletter = new Newsletter();
                RemoveFromNewsletter(command, newsletter);
                _newsletterRepository.Edit(newsletter);
                _unitOfWork.Commit();
                return new SuccessResult(NotificationCommandMessage.EmailRemovedFromNewslettersuccessfully);

            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(NotificationCommandMessage.RemovingEmailFromNewsletterFaild);
            }
        }

        private void AddToNewsletter(INewsletterCommand command, Newsletter newsletter)
        {
            if (IsEmailTaken(command.Email))
            {
                throw new EmailIsTakenException(NotificationExceptionMessage.EmailIsAlreadyInNewsletter);
            }

            newsletter.Email = command.Email;
            newsletter.NotIncluded = false;
        }

        private void RemoveFromNewsletter(INewsletterCommand command, Newsletter newsletter)
        {
            if (!IsEmailTaken(command.Email))
            {
                throw new EmailIsTakenException(NotificationExceptionMessage.EmailIsNotExist);
            }

            newsletter.NotIncluded = true;
        }

        private bool IsEmailTaken(string email)
        {
            return _membershipRepository.Exist(c => c.Email == email);
        }
    }
}
