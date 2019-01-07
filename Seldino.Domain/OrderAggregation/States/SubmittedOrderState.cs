using System;
using Seldino.CrossCutting.Enums;

namespace Seldino.Domain.OrderAggregation.States
{
    public class SubmittedOrderState : OrderState
    {
        public override OrderStatus Status
        {
            get { return OrderStatus.Completed; }
        }

        public override bool CanAddProduct()
        {
            return false;
        }

        public override void Submit(Order order)
        {
            throw new InvalidOperationException(OrderBusinessRulesMessages.OrderHasBeeenSubmited);
        }
    }
}