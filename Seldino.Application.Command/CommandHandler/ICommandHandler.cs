
namespace Seldino.Application.Command.CommandHandler
{
    internal interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        ICommandResult Execute(TCommand command);
    }
}