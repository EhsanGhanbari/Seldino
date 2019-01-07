using System;

namespace Seldino.Domain
{
    internal abstract class DomainExceptions : Exception
    {
        protected DomainExceptions(string message)
            : base(message)
        {
        }
    }
}
