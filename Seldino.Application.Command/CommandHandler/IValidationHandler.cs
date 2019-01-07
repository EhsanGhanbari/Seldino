using System.Collections.Generic;

namespace Seldino.Application.Command.CommandHandler
{
    internal interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult> Validate(TCommand command);
    }
}