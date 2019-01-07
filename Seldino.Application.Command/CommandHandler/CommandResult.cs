using System.Collections.Generic;
using System.Linq;

namespace Seldino.Application.Command.CommandHandler
{
    internal abstract class CommandResult : ICommandResult
    {
        public string Message { get; protected set; }

        public bool Success { get; protected set; }
    }

    internal class CommandResults : ICommandResults
    {
        private readonly List<ICommandResult> _results = new List<ICommandResult>();

        public void AddResult(ICommandResult result)
        {
            _results.Add(result);
        }

        public ICommandResult[] Results => _results.ToArray();

        public bool Success
        {
            get
            {
                return _results.All(result => result.Success);
            }
        }
    }

    internal class FailureResult : CommandResult
    {
        public FailureResult(string message)
        {
            Success = false;
            Message = message;
        }
    }

    internal class SuccessResult : CommandResult
    {
        public SuccessResult(string message)
        {
            Success = true;
            Message = message;
        }
    }
}