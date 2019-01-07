using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.BannerAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Seldino.Application.Command.BannerHandler
{
    internal class BannerCommandHandler :
        ICommandHandler<CreateBannerCommand>,
        ICommandHandler<EditBannerCommand>,
        ICommandHandler<ActivateBannerCommand>,
        ICommandHandler<DeactivateBannerCommand>,
        ICommandHandler<DeleteBannerCommand>,
        ICommandHandler<ConfirmBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public BannerCommandHandler(IBannerRepository bannerRepository, IMembershipRepository membershipRepository, IUnitOfWork unitOfWork, ILogger logger)
        {
            _bannerRepository = bannerRepository;
            _membershipRepository = membershipRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public ICommandResult Execute(CreateBannerCommand command)
        {
            try
            {
                var banner = new Banner();
                AddBannertAppurtenance(command, banner);
                _bannerRepository.Add(banner);
                _unitOfWork.Commit();
                return new SuccessResult(BannerCommandMessage.BannerCreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Log(exception.Message);
                return new FailureResult(BannerCommandMessage.BannerCreationFaild);
            }
        }

        public ICommandResult Execute(EditBannerCommand command)
        {
            try
            {
                var banner = _bannerRepository.GetById(command.BannerId);
                AddBannertAppurtenance(command, banner);
                _bannerRepository.Edit(banner);
                _unitOfWork.Commit();
                return new SuccessResult(BannerCommandMessage.BannerEditedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Log(exception.Message);
                return new FailureResult(BannerCommandMessage.BannerEditionFaild);
            }
        }

        public ICommandResult Execute(ActivateBannerCommand command)
        {
            if (command.BannerIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var bannerId in command.BannerIds)
            {
                try
                {
                    var banner = ActivateBanner(bannerId);
                    _bannerRepository.Edit(banner);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(BannerCommandMessage.BannerActivationFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(BannerCommandMessage.BannerActivatedSuccssfully);
        }

        public ICommandResult Execute(DeactivateBannerCommand command)
        {
            if (command.BannerIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var bannerId in command.BannerIds)
            {
                try
                {
                    var banner = DeactivateBanner(bannerId);
                    _bannerRepository.Edit(banner);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(BannerCommandMessage.BannerDeactivationFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(BannerCommandMessage.BannerDeactivatedSuccssfully);
        }

        public ICommandResult Execute(DeleteBannerCommand command)
        {
            if (command.BannerIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var bannerId in command.BannerIds)
            {
                try
                {
                    var banner = DeleteBanner(bannerId);
                    _bannerRepository.Edit(banner);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(BannerCommandMessage.BannerDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(BannerCommandMessage.BannerDeletedSuccessfully);
        }

        public ICommandResult Execute(ConfirmBannerCommand command)
        {
            if (command.BannerIds == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var bannerId in command.BannerIds)
            {
                try
                {
                    var banner = ConfirmBanner(bannerId);
                    _bannerRepository.Edit(banner);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(BannerCommandMessage.BannerConfirmationFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(BannerCommandMessage.BannerConfirmedSuccessfully);
        }

        private void AddBannertAppurtenance(IBannerCommand command, Banner banner)
        {
            AddBanner(command, banner);
            AddPicture(command, banner);
            AssigneToUser(command, banner);
        }

        private static void AddBanner(IBannerCommand command, Banner banner)
        {
            banner.BannerType = command.BannerType;
            banner.StartDate = command.StartDate;
            banner.EndDate = command.EndDate;
            banner.Fee = command.Fee;
            banner.Url = command.Url;
            banner.Caption = command.Caption;
            banner.IsConfirmed = command.IsConfirmed;
        }

        private static void AddPicture(IBannerCommand command, Banner banner)
        {
            banner.Picture = new BannerPicture
            {
                Name = command.Picture.Name,
                Address = command.Picture.Address,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };
        }

        private void AssigneToUser(IBannerCommand command, Banner banner)
        {
            var user = _membershipRepository.GetUserById(command.UserId);
            banner.Users.Add(user);
        }

        private Banner ActivateBanner(Guid bannerId)
        {
            var banner = _bannerRepository.GetById(bannerId);
            banner.IsActive = true;
            return banner;
        }

        private Banner DeactivateBanner(Guid bannerId)
        {
            var banner = _bannerRepository.GetById(bannerId);
            banner.IsActive = false;
            return banner;
        }

        private Banner DeleteBanner(Guid bannerId)
        {
            var banner = _bannerRepository.GetById(bannerId);
            banner.IsDeleted = true;
            return banner;
        }

        private Banner ConfirmBanner(Guid bannerId)
        {
            var banner = _bannerRepository.GetById(bannerId);
            banner.IsConfirmed = true;
            return banner;
        }
    }
}
