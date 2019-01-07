namespace Seldino.Application.Command.OrderHandler
{
    internal class OrderHasBeenCompletedException : CommandExceptions
    {
        public OrderHasBeenCompletedException(string message)
            : base(message)
        {
        }
    }
}
