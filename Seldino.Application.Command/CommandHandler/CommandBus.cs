using System.Collections.Generic;
using System.Web.Mvc;

namespace Seldino.Application.Command.CommandHandler
{
    /// <summary>
    /// http://weblogs.asp.net/shijuvarghese/cqrs-commands-command-handlers-and-command-dispatcher
    /// </summary>
    internal class CommandBus : ICommandBus
    {
        public ICommandResult Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = DependencyResolver.Current.GetService<ICommandHandler<TCommand>>();

            if (!((handler != null) && handler != null))
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            return handler.Execute(command);
        }

        public IEnumerable<ValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = DependencyResolver.Current.GetService<IValidationHandler<TCommand>>();
          
            if (!((handler != null) && handler != null))
            {
                throw new ValidationHandlerNotFoundException(typeof(TCommand));
            }

            return handler.Validate(command);
        }
    }
}
