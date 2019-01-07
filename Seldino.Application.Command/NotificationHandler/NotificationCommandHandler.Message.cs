using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.NotificationAggregation;
using System;
using System.Collections.Generic;

namespace Seldino.Application.Command.NotificationHandler
{
    internal partial class NotificationCommandHandler :
        ICommandHandler<CreateMessageCommand>,
        ICommandHandler<DeleteMessageCommand>,
        ICommandHandler<MarkMessageAsReadCommand>,
        ICommandHandler<CreateMessageResponseCommand>
    {
        public ICommandResult Execute(CreateMessageCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var message = new Message();
                AddMessage(command, message);

                _messageRepository.Add(message);
                _unitOfWork.Commit();
                return new SuccessResult(NotificationCommandMessage.MessageCreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(NotificationCommandMessage.MessageCreationFailed);
            }
        }

        /// <summary>
        /// Only admin and the message sender can remove the message
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(DeleteMessageCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var exceptions = new List<Exception>();
                foreach (var messageId in command.MessageIds)
                {
                    try
                    {
                        var message = DeleteUser(messageId);
                        _messageRepository.Edit(message);
                    }
                    catch (Exception exception)
                    {
                        exceptions.Add(exception);
                        return new FailureResult(NotificationCommandMessage.MessageDeletionFailed);
                    }
                }

                _unitOfWork.Commit();
                return new SuccessResult(NotificationCommandMessage.MessagesDeletedSuccessufully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(NotificationCommandMessage.MessagesDeletionFailed);
            }
        }

        public ICommandResult Execute(MarkMessageAsReadCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var exceptions = new List<Exception>();
                foreach (var messageId in command.MessageIds)
                {
                    try
                    {
                        var message = MarkAsRead(messageId);
                        _messageRepository.Edit(message);
                    }
                    catch (Exception exception)
                    {
                        exceptions.Add(exception);
                        return new FailureResult(NotificationCommandMessage.MessageCreationFailed);
                    }
                }

                _unitOfWork.Commit();
                return new SuccessResult(NotificationCommandMessage.MessageCreationFailed);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(NotificationCommandMessage.MessageDeletionFailed);
            }
        }

        private Message DeleteUser(Guid messageId)
        {
            var message = _messageRepository.GetById(messageId);
            message.IsDeleted = true;
            return message;
        }

        private Message MarkAsRead(Guid messageId)
        {
            var message = _messageRepository.GetById(messageId);
            message.IsRead = true;
            return message;
        }

        /// <summary>
        /// Create 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public ICommandResult Execute(CreateMessageResponseCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var responseMessage = new MessageResponse { Body = command.Body };
                _messageResponseRepository.Add(responseMessage);
                _unitOfWork.Commit();
                return new SuccessResult(NotificationCommandMessage.MessageResponseCreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(NotificationCommandMessage.MessageResponseCreationFailed);
            }
        }

        private static void AddMessage(CreateMessageCommand command, Message message)
        {
            message.Name = command.Name;
            message.Title = command.Title;
            message.Body = command.Body;
            message.Email = command.Email;
            message.NotificationMessageType = command.NotificationMessageType;
        }
    }
}
