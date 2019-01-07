using AutoMapper;
using Seldino.CrossCutting.Paging;
using Seldino.Domain.NotificationAggregation;
using System;
using Seldino.Infrastructure.Logging;

namespace Seldino.Application.Query.NotificationService
{
    internal class NotificationQueryService : INotificationQueryService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly INewsletterRepository _newsletterRepository;
        private readonly ILogger _logger;

        public NotificationQueryService(
            INotificationRepository notificationRepository,
            IMessageRepository messageRepository,
            INewsletterRepository newsletterRepository,
            ILogger logger)
        {
            _notificationRepository = notificationRepository;
            _messageRepository = messageRepository;
            _newsletterRepository = newsletterRepository;
            _logger = logger;
        }

        #region Notification

        public NotificationQueryResponse GetNotification(NotificationQueryRequest request)
        {
            var response = new NotificationQueryResponse();

            try
            {
                var notification = _notificationRepository.GetById(request.NotificationId);
                response.Notification = Mapper.Map<Notification, NotificationDto>(notification);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;
        }

        public NotificationsQueryResponse GetNotifications(NotificationsQueryRequest request)
        {
            var response = new NotificationsQueryResponse();

            try
            {
                var messages = _notificationRepository.GetNotifications(request);
                response.Notifications = Mapper.Map<PagingQueryResponse<Notification>, PagingQueryResponse<NotificationDto>>(messages);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;
        }

        public NotificationsQueryResponse GetActiveNotifications(NotificationsQueryRequest request)
        {
            var response = new NotificationsQueryResponse();

            try
            {
                var messages = _notificationRepository.GetActiveNotifications(request);
                response.Notifications = Mapper.Map<PagingQueryResponse<Notification>, PagingQueryResponse<NotificationDto>>(messages);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;
        }

        #endregion

        #region Message


        public MessageQueryResponse GetMessageById(MessageQueryRequest request)
        {
            var response = new MessageQueryResponse();

            try
            {
                var message = _messageRepository.GetById(request.MessageId);
                response.NotificationMessage = Mapper.Map<Message, MessageDto>(message);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;
        }

        public MessagesQueryResponse GetMessages(MessagesQueryRequest request)
        {
            var response = new MessagesQueryResponse();

            try
            {
                var messages = _messageRepository.GetMessages(request);
                response.Messages = Mapper.Map<PagingQueryResponse<Message>, PagingQueryResponse<MessageDto>>(messages);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;

        }

        public MessagesQueryResponse GetUnRepliedMessages(MessagesQueryRequest request)
        {
            var response = new MessagesQueryResponse();

            try
            {
                var messages = _messageRepository.GetUnRepliedMessages(request);
                response.Messages = Mapper.Map<PagingQueryResponse<Message>, PagingQueryResponse<MessageDto>>(messages);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;
        }

        public MessagesQueryResponse GetUnreadMessages(MessagesQueryRequest request)
        {
            var response = new MessagesQueryResponse();

            try
            {
                var messages = _messageRepository.GetUnreadMessages(request);
                response.Messages = Mapper.Map<PagingQueryResponse<Message>, PagingQueryResponse<MessageDto>>(messages);
            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;
        }


        #endregion

        #region Newsletter

        public NewsletterQueryResponse GetNewsletteEmails(NewsletterQueryRequest request)
        {
            var response = new NewsletterQueryResponse();

            try
            {
                var newsletters = _newsletterRepository.GetAll(request.PageIndex, request.PageSize);
                response.NewsletterEmails = Mapper.Map<PagingQueryResponse<Newsletter>, PagingQueryResponse<NewsletterDto>>(newsletters);

            }
            catch (Exception exception)
            {
                _logger.Log(exception);
                response.Failed = true;
            }

            return response;
        }

        #endregion
    }
}
