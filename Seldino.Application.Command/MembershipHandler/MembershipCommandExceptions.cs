namespace Seldino.Application.Command.MembershipHandler
{
    internal class MembershipCommandException : CommandExceptions
    {
        public MembershipCommandException(string message)
            : base(message)
        {
        }
    }

    internal class EmailIsTakenException : MembershipCommandException
    {
        public EmailIsTakenException(string message)
            : base(message)
        {
        }
    }

    internal class InactiveUserException : MembershipCommandException
    {
        public InactiveUserException(string message)
            : base(message)
        {
        }
    }

    internal class InvalidCredentialException : MembershipCommandException
    {
        public InvalidCredentialException(string message)
            : base(message)
        {
        }
    }

    internal class IncorrectOldPasswordException : MembershipCommandException
    {
        public IncorrectOldPasswordException(string message)
            : base(message)
        {
        }
    }
}
