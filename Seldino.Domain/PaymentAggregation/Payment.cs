using System;
using System.Collections.Generic;
using Seldino.CrossCutting.Enums;
using Seldino.Domain.MembershipAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.PaymentAggregation
{

    public class Payment : EntityBase, IAggregateRoot
    {
        private ICollection<User> _users = new List<User>();

        public Payment(DateTime paymentDate, string transactionId, string merchant, decimal amount)
        {
            PaymentDate = paymentDate;
            TransactionId = transactionId;
            Merchant = merchant;
            Amount = amount;
        }

        public DateTime PaymentDate { get; set; }

        public string TransactionId { get; set; }

        public string Merchant { get; set; }

        public decimal Amount { get; set; }

        public PaymentStatus Status { get; set; }

        public virtual ICollection<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
            set { _users = value; }
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(TransactionId))
                AddBrokenRule(PaymentBusinessRule.TransactionIdRequired);

            if (string.IsNullOrEmpty(Merchant))
                AddBrokenRule(PaymentBusinessRule.MerchantRequired);

            if (Amount < 0)
                AddBrokenRule(PaymentBusinessRule.AmountValid);           
        }
    }
}
