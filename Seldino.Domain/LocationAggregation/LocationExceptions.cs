namespace Seldino.Domain.LocationAggregation
{
    internal class InvalidAddressException : DomainExceptions
    {
        public InvalidAddressException(string message)
            : base(message)
        {
        }
    }
}
