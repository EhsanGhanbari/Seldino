namespace Seldino.Application.Command.DiscountHandler
{
    internal class DiscountCommandExceptions : CommandExceptions
    {
        public DiscountCommandExceptions(string message)
            : base(message)
        {
        }
    }

    internal class DiscountAlreadyRunningException : CommandExceptions
    {
        public DiscountAlreadyRunningException(string message)
            : base(message)
        {
        }
    }

    internal class DiscountAlreadyStoppedException : CommandExceptions
    {
        public DiscountAlreadyStoppedException(string message)
            : base(message)
        {
        }
    }
}
