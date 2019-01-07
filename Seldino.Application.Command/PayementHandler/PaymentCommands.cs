using System;
using FluentValidation.Attributes;
using Seldino.Application.Command.CommandHandler;

namespace Seldino.Application.Command.PayementHandler
{
    [Validator(typeof(PaymentCommandValidation))]
    public class ChargeAccountCommand : ICommand
    {
        public decimal Amount { get; set; }

        public string TransactionId { get; set; }
    }

    public class SetOrderPaymentCommand : ICommand
    {
        //public Guid OrderId { get; set; }

        //public string PaymentToken { get; set; }

        //public decimal Amount { get; set; }

        //public string PaymentMerchant { get; set; }

        public string RedirectUrl { get; set; }

        public string ResNum { get; set; }

        public string RefNum { get; set; }

        public string State { get; set; }

        public string Langauge { get; set; }

        public string CardPanHash { get; set; }
    }

    public class DeletePaymentCommand : ICommand
    {
        public Guid[] PaymentIds { get; set; }
    }
}
