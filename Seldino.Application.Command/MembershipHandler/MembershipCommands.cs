using System;
using FluentValidation.Attributes;
using Seldino.Application.Command.CommandHandler;

namespace Seldino.Application.Command.MembershipHandler
{
    [Validator(typeof(RegisterUserCommandValidation))]
    public class RegisterUserCommand : ICommand
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public RoleCommand Role { get; set; }
    }

    [Validator(typeof(UpdateProfileCommandValidation))]
    public class UpdateProfileCommand : ICommand
    {
        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string CellPhone { get; set; }

        public PictureCommand Picture { get; set; }
    }

    public class DeleteUserCommand : ICommand
    {
        public Guid[] UserIds { get; set; }
    }

    public class ActivateUserCommand : ICommand
    {
        public Guid[] UserIds { get; set; }
    }

    public class DeactiveUserCommand : ICommand
    {
        public Guid[] UserIds { get; set; }
    }

    [Validator(typeof(ChangePasswordCommandValidation))]
    public class ChangePasswordCommand : ICommand
    {
        public Guid UserId { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }


    [Validator(typeof(SendPasswordRecoveryLinkCommandValidation))]
    public class SendPasswordRecoveryLinkCommand : ICommand
    {
        public string Email { get; set; }
    }

    public class AssignRoleCommand : ICommand
    {
        public Guid UserId { get; set; }

        public string Role { get; set; }
    }

    [Validator(typeof(RoleCommand))]
    public class RoleCommand : ICommand
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public interface IUserIdentity
    {
        Guid Id { get; set; }

        string Email { get; set; }

        string Name { get; set; }
    }

    public class UserIdentity : IUserIdentity
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}
