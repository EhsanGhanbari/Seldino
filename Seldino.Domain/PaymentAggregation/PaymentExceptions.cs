
namespace Seldino.Domain.PaymentAggregation
{
    internal class PaymentAmountDoesNotEqualOrderTotalException : DomainExceptions
    {
        public PaymentAmountDoesNotEqualOrderTotalException(string message)
            : base(message)
        {
        }
    }
}
