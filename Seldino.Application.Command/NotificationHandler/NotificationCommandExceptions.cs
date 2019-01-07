namespace Seldino.Application.Command.NotificationHandler
{
    #region Newsletter
    internal class EmailIsTakenException : CommandExceptions
    {
        public EmailIsTakenException(string message)
            : base(message)
        {
        }
    }
    #endregion
}
