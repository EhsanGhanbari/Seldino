namespace Seldino.Application.Command.StoreHandler
{
    internal class PictureIsNUllOrEmptyException : CommandExceptions
    {
        public PictureIsNUllOrEmptyException(string message)
            : base(message)
        {
        }
    }
}
