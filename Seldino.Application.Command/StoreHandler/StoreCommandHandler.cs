using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Application.Command.CommandHandler;
using Seldino.Domain.DiscountAggregation;
using Seldino.Domain.LocationAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.StoreAggregation;
using Seldino.Domain.StoreAggregation.StoreComments;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;

namespace Seldino.Application.Command.StoreHandler
{
    internal partial class StoreCommandHandler :
        ICommandHandler<CreateStoreCommand>,
        ICommandHandler<EditStoreCommand>,
        ICommandHandler<DeleteStoreCommand>,
        ICommandHandler<ActivateStoreCommand>,
        ICommandHandler<DeactiveStoreCommand>,
        ICommandHandler<ApplyStoreDiscountCommand>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IStoreCommentRepository _storeCommentRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public StoreCommandHandler(IStoreRepository storeRepository, IMembershipRepository membershipRepository, IUnitOfWork unitOfWork, ILogger logger, IStoreCommentRepository storeCommentRepository, IDiscountRepository discountRepository)
        {
            _storeRepository = storeRepository;
            _storeCommentRepository = storeCommentRepository;
            _discountRepository = discountRepository;
            _membershipRepository = membershipRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public ICommandResult Execute(CreateStoreCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var store = new Store();
                AddStore(command, store);
                _storeRepository.Add(store);
                _unitOfWork.Commit();
                return new SuccessResult(StoreCommandMessage.StoreCreatedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(StoreCommandMessage.StoreCreationFailed);
            }
        }

        public ICommandResult Execute(EditStoreCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var store = new Store();
                AddStore(command, store);
                _storeRepository.Edit(store);
                _unitOfWork.Commit();
                return new SuccessResult(StoreCommandMessage.StoreEditedSuccessfully);
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(StoreCommandMessage.StoreEditionFailed);
            }
        }

        public ICommandResult Execute(DeleteStoreCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var storeId in command.StoreIds)
            {
                try
                {
                    var store = DeleteStore(storeId);
                    _storeRepository.Edit(store);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(StoreCommandMessage.StoreDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(StoreCommandMessage.StoreDeletedSuccessfully);
        }

        public ICommandResult Execute(ActivateStoreCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var storeId in command.StoreIds)
            {
                try
                {
                    var store = ActivateStore(storeId);
                    _storeRepository.Edit(store);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(StoreCommandMessage.StoreActivationFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(StoreCommandMessage.StoreActivatedSuccessfully);
        }

        public ICommandResult Execute(DeactiveStoreCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var storeId in command.StoreIds)
            {
                try
                {
                    var store = DeactivateStore(storeId);
                    _storeRepository.Edit(store);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(StoreCommandMessage.StoreDeactivationFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(StoreCommandMessage.StoreDeactivatedSuccessfully);
        }

        public ICommandResult Execute(ApplyStoreDiscountCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var storeId in command.StoreIds)
            {
                try
                {
                    var discount = _discountRepository.GetById(command.DiscountId);

                    if (discount == null)
                    {
                        return new FailureResult("قالب تخفیف مورد نظر یافت نشد");
                    }

                    var store = ApplyDiscount(storeId, discount);
                    _storeRepository.Edit(store);
                }
                catch (Exception exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult("اعمال تخفیف با خطا مواجه شد");
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult("اعمال تخفیف با موفقیت انجام شد");
        }

        private Store DeleteStore(Guid storeId)
        {
            var store = _storeRepository.GetById(storeId);
            store.IsDeleted = true;
            return store;
        }

        private Store ActivateStore(Guid storeId)
        {
            var store = _storeRepository.GetById(storeId);
            store.IsInactive = false;
            return store;
        }

        private Store DeactivateStore(Guid storeId)
        {
            var store = _storeRepository.GetById(storeId);
            store.IsInactive = true;
            return store;
        }

        private Store ApplyDiscount(Guid storeId, Discount discount)
        {
            var store = _storeRepository.GetById(storeId);
            store.Discounts.Add(discount);
            return store;
        }

        private void AddStore(IStoreCommand command, Store store)
        {
            store.Name = command.Name;
            store.Phone = command.Phone;
            AddStorePictures(command, store);
            AddLocation(command, store);
            AssignToUser(command, store);
        }

        private static void AddStorePictures(IStoreCommand command, Store store)
        {
            if (command.Pictures == null)
            {
                throw new PictureIsNUllOrEmptyException(StoreWxceptionMessage.StorePictureIsRequired);
            }

            foreach (var picture in command.Pictures.Select(item => new StorePicture
            {
                Name = item.Name,
                Address = item.Address,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
            }))
            {
                store.AddPicture(picture);
            }
        }

        private static void AddLocation(IStoreCommand command, Store store)
        {
            var address = command.Location.Address;

            var location = new Location
            {
                CountryName = command.Location.Country.Name,
                StateName = command.Location.State.Name,
                Latitude = command.Location.Latitude,
                Longitude = command.Location.Longitude,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                Address = new Address(address.AddressLine, address.City, address.ZipCode)
                {
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                }
            };

            store.Location = location;
        }

        private void AssignToUser(IStoreCommand command, Store store)
        {
            var user = _membershipRepository.GetUserById(command.UserId);
            store.Users.Add(user);
        }

    }
}
