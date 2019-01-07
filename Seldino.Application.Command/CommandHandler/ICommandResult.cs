namespace Seldino.Application.Command.CommandHandler
{
    public interface ICommandResult
    {
        string Message { get; }

        bool Success { get; }
    }

    public interface ICommandResults
    {
        ICommandResult[] Results { get; }

        bool Success { get; }
    }
}