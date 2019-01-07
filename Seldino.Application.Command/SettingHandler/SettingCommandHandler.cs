using System;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.SettingAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;

namespace Seldino.Application.Command.SettingHandler
{
    internal class SettingCommandHandler : ICommandHandler<EditSettingCommand>
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public SettingCommandHandler(ISettingRepository settingRepository, IUnitOfWork unitOfWork, ILogger logger)
        {
            _settingRepository = settingRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public ICommandResult Execute(EditSettingCommand command)
        {
            try
            {
                var setting = new Setting();
                AddSettingDependencies(setting,command);
                _settingRepository.Edit(setting);
                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
            }

            return new SuccessResult("");
        }

        private void AddSettingDependencies(Setting setting, EditSettingCommand command)
        {
            setting.BlogSetting = new BlogSetting
            {
                IsCommentAutoPublished = command.BlogSetting.IsCommentAutoPublished
            };

            setting.BasketSetting = new BasketSetting
            {
                EmailNotificationEnabled = command.BasketSetting.EmailNotificationEnabled,
            };

            setting.DocumentSetting = new DocumentSetting
            {
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            setting.OrderSetting = new OrderSetting
            {
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            setting.OrderSetting = new OrderSetting
            {
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            setting.StoreSetting = new StoreSetting
            {
                IsAutoPublished = command.StoreSetting.IsAutoPublished,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            setting.BannerSetting = new BannerSetting
            {
                IsAutoPublished = command.BannerSetting.IsAutoPublished,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            setting.BasicSetting = new BasicSetting
            {
                WebsiteTitle = command.BasicSetting.WebsiteTitle,
                WebsiteUrl = command.BasicSetting.WebsiteUrl,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            setting.ProductSetting = new ProductSetting
            {
                IsAutoPublished = command.ProductSetting.IsAutoPublished,
                IsCommentAutoPublished = command.ProductSetting.IsCommentAutoPublished,
                CommentIntervalTime = command.ProductSetting.CommentIntervalTime,
                CommentLength = command.ProductSetting.CommentLength,
                ImagePrefixAddress = command.ProductSetting.ImagePrefixAddress,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            setting.SeoSetting = new SeoSetting
            {
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };
        }
    }
}
