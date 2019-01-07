using Seldino.CrossCutting.Enums;
using Seldino.Domain.LocationAggregation;
using Seldino.Domain.MembershipAggregation;
using Seldino.Domain.OrderAggregation.States;
using Seldino.Domain.PaymentAggregation;
using Seldino.Domain.ProductAggregation;
using Seldino.Domain.ShippingAggregation;
using Seldino.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seldino.Domain.OrderAggregation
{
    public class Order : EntityBase, IAggregateRoot
    {
        private readonly IList<OrderItem> _items;
        private Payment _payment;
        private IOrderState _state;

        public Order()
        {
            _items = new List<OrderItem>();
            _state = OrderStates.Open;
        }

        public User User { get; set; }

        public decimal ShippingCharge { get; set; }

        public Guid ShippingServiceId { get; set; }

        public virtual ShippingService ShippingService { get; set; }

        public Guid LocationId { get; set; }

        public virtual Location Location { get; set; }

        public Guid PaymentId { get; set; }

        public virtual Payment Payment
        {
            get { return _payment; }
            set { _payment = value; } 
        }

        public decimal ItemTotal()
        {
            return Items.Sum(i => i.LineTotal());
        }

        public decimal Total()
        {
            return Items.Sum(i => i.LineTotal()) + ShippingCharge;
        }

        public void SetPayment(Payment payment)
        {
            if (OrderHasBeenPaidFor())
                throw new OrderAlreadyPaidForException(GetDetailsOnExisitingPayment());

            if (OrderTotalMatches(payment))
                _payment = payment;
            else
                throw new PaymentAmountDoesNotEqualOrderTotalException(GetDetailsOnIssueWith(payment));

            _state.Submit(this);
        }

        private string GetDetailsOnExisitingPayment()
        {
            return String.Format(OrderBusinessRulesMessages.PaymentHasBeenPaid,
                                 Payment.Amount, Payment.PaymentDate, Payment.TransactionId);
        }

        private string GetDetailsOnIssueWith(Payment payment)
        {
            return String.Format(OrderBusinessRulesMessages.PaymentIsNotValid,
                Total(), payment.Amount, payment.TransactionId);
        }

        public bool OrderHasBeenPaidFor()
        {
            return Payment != null && OrderTotalMatches(Payment);
        }

        private bool OrderTotalMatches(Payment payment)
        {
            return Total() == payment.Amount;
        }

        public ICollection<OrderItem> Items
        {
            get { return _items; }
        }

        public OrderStatus Status
        {
            get { return _state.Status; }
        }

        public void AddItem(Product product, int qty)
        {
            if (_state.CanAddProduct())
            {
                if (!OrderContains(product))
                    _items.Add(OrderItemFactory.CreateItemFor(product, this, qty));
            }
            else
            {
                throw new CannotAmendOrderException(String.Format(OrderBusinessRulesMessages.CanNotAddItemToOrder, Status));
            }
        }

        private bool OrderContains(Product product)
        {
            return _items.Any(i => i.Contains(product));
        }

        internal void SetStateTo(IOrderState state)
        {
            _state = state;
        }

        public override string ToString()
        {
            var orderInfo = new StringBuilder();

            foreach (var item in _items)
            {
                orderInfo.AppendLine(String.Format("{0} از {1} ", item.Quantity, item.Product.Name));
            }

            orderInfo.AppendLine(String.Format("ارسال: {0}", ShippingCharge));
            orderInfo.AppendLine(String.Format("جمع: {0}", Total()));

            return orderInfo.ToString();
        }

        protected override void Validate()
        {
            if (IsDeleted)
                AddBrokenRule(OrderBusinessRules.ProductHasBeenDeleted);

            if (CreationDate == DateTime.MinValue)
                AddBrokenRule(OrderBusinessRules.CreatedDateRequired);

            if (Location == null)
                base.AddBrokenRule(OrderBusinessRules.DeliveryAddressRequired);

            if (Items == null || !Items.Any())
                AddBrokenRule(OrderBusinessRules.ItemsRequired);
            else
            {
                if (Items.Any(i => i.GetBrokenRules().Any()))
                {
                    foreach (var item in Items.Where(i => i.GetBrokenRules().Any()))
                    {
                        foreach (var businessRule in item.GetBrokenRules())
                        {
                            AddBrokenRule(businessRule);
                        }
                    }
                }
            }
        }
    }
}
