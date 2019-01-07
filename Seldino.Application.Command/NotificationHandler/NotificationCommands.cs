using System;
using FluentValidation.Attributes;
using Seldino.Application.Command.CommandHandler;
using Seldino.CrossCutting.Enums;

namespace Seldino.Application.Command.NotificationHandler
{
    #region Notification

    public interface INotificationCommand : ICommand
    {
        string Title { get; set; }
        string Body { get; set; }
    }

    public class NotificationCommand : INotificationCommand
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class CreateNotificationCommand : NotificationCommand
    {
    }

    public class EditNotificationCommand : NotificationCommand
    {
        public Guid NotificationId { get; set; }
    }

    public class DeleteNotificationCommand : ICommand
    {
        public Guid[] NotificationIds { get; set; }
    }

    public class TerminateNotificationCommand : ICommand
    {
        public Guid[] NotificationIds { get; set; }
    }
    
    #endregion

    #region Message

    [Validator(typeof(CreateMessageCommandValidation))]
    public class CreateMessageCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public NotificationMessageType NotificationMessageType { get; set; }
    }


    public class DeleteMessageCommand : ICommand
    {
        public Guid[] MessageIds { get; set; }
    }

    public class MarkMessageAsReadCommand : ICommand
    {
        public Guid[] MessageIds { get; set; }
    }

    [Validator(typeof(CreateMessageResponseCommandValidation))]
    public class CreateMessageResponseCommand : ICommand
    {
        public Guid MessageId { get; set; }
        public string Body { get; set; }
    }

    #endregion

    #region Newsletter

    internal interface INewsletterCommand : ICommand
    {
        string Email { get; set; }
    }

    [Validator(typeof(NewsletterCommandValidation))]
    public class NewsletterCommand : INewsletterCommand
    {
        public string Email { get; set; }
    }

    public class AddEmailToNewsletterCommand : NewsletterCommand
    {
    }

    public class RemoveEmailFromNewsLetterCommand : NewsletterCommand
    {
    }

    #endregion
}
