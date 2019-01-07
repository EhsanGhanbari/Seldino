using System;
using Seldino.CrossCutting.Enums;

namespace Seldino.Application.Query.NotificationService
{
    #region Notification

    public class NotificationDto
    {
        public Guid NotificationId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsActive { get; set; }
    }
    #endregion

    #region Message
    public class MessageDto
    {
        public Guid MessageId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsRead { get; set; }

        public bool IsReplied { get; set; }

        public NotificationMessageType NotificationMessageType { get; set; }

        public DateTime CreationDate { get; set; }
    }

    public class MessageResponseDto
    {
        public string Body { get; set; }
    }

    #endregion

    #region Newsletter
    public class NewsletterDto
    {
        public string Email { get; set; }
    }

    #endregion
}
