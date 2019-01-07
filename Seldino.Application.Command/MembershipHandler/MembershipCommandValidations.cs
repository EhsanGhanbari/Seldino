using System;
using FluentValidation;

namespace Seldino.Application.Command.MembershipHandler
{
    internal class RegisterUserCommandValidation : AbstractValidator<RegisterUserCommand>
    {
        /// <summary>
        /// TODO PasswordCompltexity
        /// http://www.webdevbros.net/2010/12/03/asp-net-mvc-fluent-validation-and-tesing/
        /// </summary>
        public RegisterUserCommandValidation()
        {

            RuleFor(u => u.Email).NotEmpty().WithMessage(MembershipValidationMessages.EmailIsRequired)
                .EmailAddress().WithMessage(MembershipValidationMessages.EmailFormatIsIncorrect);

            RuleFor(u => u.Password).NotEmpty().WithMessage(MembershipValidationMessages.PasswrdIsRequired)
                .Length(6, 16).WithMessage(MembershipValidationMessages.PasswordLenghtIsNotInRegularForm);

            RuleFor(u => u.ConfirmPassword)
                .NotEmpty()
                .WithMessage(MembershipValidationMessages.ConfirmPasswrdIsRequired)
                .Equal(u => u.Password)
                .WithMessage(MembershipValidationMessages.ConfirmPasswordIsNotMatchWithPassword);
        }
    }

    internal class UpdateProfileCommandValidation : AbstractValidator<UpdateProfileCommand>
    {
        public UpdateProfileCommandValidation()
        {
            RuleFor(p => p.FirstName).Length(2, 30).WithMessage(MembershipValidationMessages.NameIsNotInReguarLenght);
            RuleFor(p => p.LastName)
                .Length(2, 30)
                .WithMessage(MembershipValidationMessages.LastNameIsNotInRegularLenght);
            RuleFor(p => p.CellPhone)
                .Must(CheckForAnyPhoneNumber)
                .WithMessage(MembershipValidationMessages.CellPhoneNumerIsNotInCorrectFormat);
        }

        private static bool CheckForAnyPhoneNumber(UpdateProfileCommand customer, string phoneNumber)
        {
            return (!string.IsNullOrEmpty(customer.CellPhone));
        }
    }
    internal class ChangePasswordCommandValidation : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidation()
        {
            RuleFor(u => u.CurrentPassword).NotEmpty().WithMessage(MembershipValidationMessages.PasswrdIsRequired);

            RuleFor(u => u.NewPassword).NotEmpty().WithMessage(MembershipValidationMessages.PasswrdIsRequired)
               .Length(6, 16).WithMessage(MembershipValidationMessages.PasswordLenghtIsNotInRegularForm);

            RuleFor(u => u.ConfirmPassword)
                .NotEmpty()
                .WithMessage(MembershipValidationMessages.ConfirmPasswrdIsRequired)
                .Equal(u => u.NewPassword)
                .WithMessage(MembershipValidationMessages.ConfirmPasswordIsNotMatchWithPassword);
        }
    }

    internal class SendPasswordRecoveryLinkCommandValidation : AbstractValidator<SendPasswordRecoveryLinkCommand>
    {
        public SendPasswordRecoveryLinkCommandValidation()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage(MembershipValidationMessages.EmailIsRequired)
               .EmailAddress().WithMessage(MembershipValidationMessages.EmailFormatIsIncorrect);
        }
    }

    internal class RoleCommandValidation : AbstractValidator<RoleCommand>
    {
        public RoleCommandValidation()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage(MembershipValidationMessages.RoleNameIsRequired);
        }
    }
}
