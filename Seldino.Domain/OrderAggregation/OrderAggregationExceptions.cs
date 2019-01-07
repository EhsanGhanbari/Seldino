namespace Seldino.Domain.OrderAggregation
{
    internal class PaymentAmountDoesNotEqualOrderTotalException : DomainExceptions
    {
        public PaymentAmountDoesNotEqualOrderTotalException(string message)
            : base(message)
        {
        }
    }

    internal class CannotAmendOrderException : DomainExceptions
    {
        public CannotAmendOrderException(string message)
            : base(message)
        {
        }
    }

    internal class OrderAlreadyPaidForException : DomainExceptions
    {
        public OrderAlreadyPaidForException(string message)
            : base(message)
        {
        }
    }

    internal class InvalidDeliveryAddressException : DomainExceptions
    {
        public InvalidDeliveryAddressException(string message)
            : base(message)
        {
        }
    }
}
