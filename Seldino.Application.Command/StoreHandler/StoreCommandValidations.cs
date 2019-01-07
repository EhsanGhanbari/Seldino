using FluentValidation;

namespace Seldino.Application.Command.StoreHandler
{

    internal class StoreCommandValidation : AbstractValidator<CreateStoreCommand>
    {
        public StoreCommandValidation()
        {
            RuleFor(s => s.Name).Length(2, 50).WithMessage(StoreValidationMessage.StoreNameIsRequired);
            RuleFor(s => s.Phone).Must(CheckForAnyPhoneNumber).WithMessage(StoreValidationMessage.StorePhoneIsIncorrect);
        }

        private static bool CheckForAnyPhoneNumber(CreateStoreCommand store, string phoneNumber)
        {
            return (!string.IsNullOrEmpty(store.Phone));
        }
    }
}
