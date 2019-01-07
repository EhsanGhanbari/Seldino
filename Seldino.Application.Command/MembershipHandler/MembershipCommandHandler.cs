using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Application.Command.CommandHandler;
using Seldino.CrossCutting.Security;
using Seldino.Domain.BasketAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Infrastructure.Logging;
using Seldino.Repository.Infrastructure;

namespace Seldino.Application.Command.MembershipHandler
{
    internal class MembershipCommandHandler :
        ICommandHandler<RegisterUserCommand>,
        ICommandHandler<UpdateProfileCommand>,
        ICommandHandler<DeleteUserCommand>,
        ICommandHandler<ActivateUserCommand>,
        ICommandHandler<DeactiveUserCommand>,
        ICommandHandler<ChangePasswordCommand>,
        ICommandHandler<SendPasswordRecoveryLinkCommand>,
        ICommandHandler<AssignRoleCommand>
    {
        private readonly ILogger _logger;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MembershipCommandHandler(
            IMembershipRepository membershipRepository,
            IUnitOfWork unitOfWork,
            ILogger logger,
            IBasketRepository basketRepository)
        {
            _membershipRepository = membershipRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _basketRepository = basketRepository;
        }

        public ICommandResult Execute(ActivateUserCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var userId in command.UserIds)
            {
                try
                {
                    var user = ActivateUser(userId);
                    _membershipRepository.Edit(user);
                }
                catch (MembershipCommandException exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(MembershipCommandMessage.UserActivationFaild);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(MembershipCommandMessage.UserActivatedSuccessfully);
        }

        public ICommandResult Execute(AssignRoleCommand command)
        {
            try
            {
                //ToDo Assign Role 
                _unitOfWork.Commit();
                return new SuccessResult("");
            }
            catch (Exception exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult("");
            }
        }

        public ICommandResult Execute(ChangePasswordCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var user = _membershipRepository.GetById(command.UserId);

                if (Cryptography.IsValidated(command.NewPassword, command.CurrentPassword))
                {
                    throw new IncorrectOldPasswordException(MembershipExceptionMessage.IncorrectOldPassword);
                }

                var newHashedPassword = Cryptography.Hash(command.NewPassword);
                user.Password = newHashedPassword;
                _membershipRepository.Edit(user);
                _unitOfWork.Commit();
                return new SuccessResult(MembershipCommandMessage.PasswordChangedSuccessfully);
            }
            catch (MembershipCommandException exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(MembershipCommandMessage.PasswordChandingFaild);
            }
        }

        public ICommandResult Execute(DeactiveUserCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();

            foreach (var userId in command.UserIds)
            {
                try
                {
                    var user = DeactivateUser(userId);
                    _membershipRepository.Edit(user);
                }
                catch (MembershipCommandException exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(MembershipCommandMessage.UserDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(MembershipCommandMessage.UserDeactivatedSuccessfully);
        }

        public ICommandResult Execute(DeleteUserCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException();
            }

            var exceptions = new List<Exception>();
            foreach (var userId in command.UserIds)
            {
                try
                {
                    var user = DeleteUser(userId);
                    _membershipRepository.Edit(user);
                }
                catch (MembershipCommandException exception)
                {
                    exceptions.Add(exception);
                    return new FailureResult(MembershipCommandMessage.UserDeletionFailed);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }

            _unitOfWork.Commit();
            return new SuccessResult(MembershipCommandMessage.UserEditedSuccessfully);
        }

        public ICommandResult Execute(RegisterUserCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var user = new User();
                AddUser(command, user);
                _membershipRepository.Add(user);
                _unitOfWork.Commit();
                return new SuccessResult(MembershipCommandMessage.UserCreatedSuccessfully);
            }
            catch (MembershipCommandException exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(MembershipCommandMessage.UserCreationFailed);
            }
        }

        public ICommandResult Execute(SendPasswordRecoveryLinkCommand command)
        {
            var isEmailExist = _membershipRepository.Exist(c => c.Email == command.Email);

            if (isEmailExist)
            {
                return new SuccessResult(MembershipCommandMessage.ForgotPasswordOperationSucceded); //Todo Send Password recovery
            }

            return new FailureResult(MembershipCommandMessage.ForgotPasswordOperationFaild);
        }

        public ICommandResult Execute(UpdateProfileCommand command)
        {
            try
            {
                if (command == null)
                {
                    throw new ArgumentNullException();
                }

                var user = _membershipRepository.GetById(command.UserId);
                UpdateUserProfile(command, user);
                _membershipRepository.Edit(user);
                _unitOfWork.Commit();
                return new SuccessResult(MembershipCommandMessage.UserEditedSuccessfully);
            }
            catch (MembershipCommandException exception)
            {
                _logger.Error(exception.Message);
                return new FailureResult(MembershipCommandMessage.UserEditionFailed);
            }
        }

        private User DeleteUser(Guid userId)
        {
            var user = _membershipRepository.GetById(userId);
            user.IsDeleted = true;
            return user;
        }

        private User ActivateUser(Guid userId)
        {
            var user = _membershipRepository.GetById(userId);
            user.IsActive = true;
            return user;
        }

        private User DeactivateUser(Guid userId)
        {
            var user = _membershipRepository.GetById(userId);
            user.IsActive = false;
            return user;
        }

        private void AddUser(RegisterUserCommand command, User user)
        {
            if (IsEmailTaken(command.Email))
            {
                throw new EmailIsTakenException(MembershipExceptionMessage.EmailIsTaken);
            }

            user.Email = command.Email;
            user.Password = Cryptography.Hash(command.Password);
            user.IsActive = true; //ToDo should active user after a verification
            AssignDefaultRole(user);
        }

        private bool IsEmailTaken(string email)
        {
            return _membershipRepository.Exist(c => c.Email == email);
        }

        private static void UpdateUserProfile(UpdateProfileCommand command, User user)
        {
            user.Profile = new Profile
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                CellPhone = command.CellPhone,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                Avatar = new ProfileAvatar
                {
                    Name = command.Picture.Name,
                    Address = command.Picture.Address,
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                }
            };
        }

        private void AssignDefaultRole(User user)
        {
            var role = _membershipRepository.GetDefaultRole();
            user.Role = role;
        }
    }
}