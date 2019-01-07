using System;

namespace Seldino.Application.Command
{
    internal abstract class CommandExceptions : Exception
    {
        protected CommandExceptions(string message)
            : base(message)
        {
        }
    }
}
