using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.NotificationAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;
using System;
using System.Collections.Generic;

namespace Seldino.Application.Command.NotificationHandler
{
    internal partial class NotificationCommandHandler :
        ICommandHandler<CreateNotificationCommand>,
        ICommandHandler<EditNotificationCommand>,
        ICommandHandler<TerminateNotificationCommand>,
        ICommandHandler<DeleteNotificationCommand>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMessageResponseRepository _messageResponseRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly INewsletterRepository _newsletterRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public NotificationCommandHandler(INotificationRepository notificationRepository, IMessageResponseRepository messageResponseRepository, IMessageRepository messageRepository, INewsletterRepository newsletterRepository,IMembershipRepository membershipRepository, IUnitOfWork unitOfWork, ILogger logger)
        {
            _notificationRepository = notificationRepository;
            _messageResponseRepository = messageResponseRepository;
            _messageRepository = messageRepository;
            _newsletterRepository = newsletterRepository;
            _membershipRepository = membershipRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public ICommandResult Execute(CreateNotificationCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var notification = new Notification { Title = command.Title, Body = command.Body };

                _notificationRepository.Add(notification);
                _unitOfWork.Commit();
                return new SuccessResult(NotificationCommandMessage.NotificationCreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(NotificationCommandMessage.NotifactionCreationFaild);
            }
        }

        public ICommandResult Execute(EditNotificationCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var notification = new Notification { Id = command.NotificationId, Title = command.Title, Body = command.Body };

                _notificationRepository.Edit(notification);
                _unitOfWork.Commit();
                return new SuccessResult(NotificationCommandMessage.NotifcationEditedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(NotificationCommandMessage.NotificationEditionFaild);
            }
        }

        public ICommandResult Execute(TerminateNotificationCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var exceptions = new List<Exception>();
                foreach (var notificationId in command.NotificationIds)
                {
                    try
                    {
                        var notification = TerminateNotification(notificationId);
                        _notificationRepository.Edit(notification);
                    }
                    catch (Exception exception)
                    {
                        exceptions.Add(exception);
                        return new FailureResult(NotificationCommandMessage.NotificationTerminationFaild);
                    }
                }

                _unitOfWork.Commit();
                return new SuccessResult(NotificationCommandMessage.NotificationTerminatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(NotificationCommandMessage.NotificationTerminationFaild);
            }
        }

        public ICommandResult Execute(DeleteNotificationCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var exceptions = new List<Exception>();
                foreach (var messageId in command.NotificationIds)
                {
                    try
                    {
                        var notification = DeleteNotification(messageId);
                        _notificationRepository.Edit(notification);
                    }
                    catch (Exception exception)
                    {
                        exceptions.Add(exception);
                        return new FailureResult(NotificationCommandMessage.NotificationDeletionFailed);
                    }
                }

                _unitOfWork.Commit();
                return new SuccessResult(NotificationCommandMessage.NotificationDeletedSuccessufully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(NotificationCommandMessage.NotificationDeletionFailed);
            }
        }

        private Notification DeleteNotification(Guid notificationId)
        {
            var notification = _notificationRepository.GetById(notificationId);
            notification.IsDeleted = true;
            return notification;
        }

        private Notification TerminateNotification(Guid notificationId)
        {
            var notification = _notificationRepository.GetById(notificationId);
            notification.IsActive = true;
            return notification;
        }
    }
}
