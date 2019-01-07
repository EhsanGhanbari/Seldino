using System.Collections.Generic;

namespace Seldino.Application.Command.CommandHandler
{
    public interface ICommandBus
    {
        ICommandResult Send<TCommand>(TCommand command) where TCommand : ICommand;

        IEnumerable<ValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}