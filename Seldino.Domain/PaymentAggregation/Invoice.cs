﻿using System;
using Seldino.Domain.MembershipAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.PaymentAggregation
{
    public class Invoice : EntityBase
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid PaymentId { get; set; }

        public virtual Payment Payment { get; set; }

        public decimal Amount { get; set; }

        /// <summary>
        /// Invoice code generated by system for every invoice
        /// </summary>
        public string Code { get; set; }


        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
