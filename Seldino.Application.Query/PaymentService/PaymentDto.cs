using System;
using Seldino.Application.Query.MembershipService;
using Seldino.CrossCutting.Enums;
using Seldino.Domain.PaymentAggregation;

namespace Seldino.Application.Query.PaymentService
{
    public class PaymentDto
    {
        public Guid PaymentId { get; set; }

        public DateTime PaymentDate { get; set; }

        public string TransactionId { get; set; }

        public string Merchant { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatus Status { get; set; }
    }

    public class InvoiceDto
    {
        public UserDto User { get; set; }

        public PaymentDto Payment { get; set; }

        public decimal Amount { get; set; }

        public string Code { get; set; }
    }
}
