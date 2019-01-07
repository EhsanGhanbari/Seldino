using System;
using System.Collections.Generic;
using Seldino.Domain.ProductAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.OrderAggregation
{
    public class OrderItem : EntityBase
    {
        private readonly Product _product;

        public OrderItem()
        {
        }

        public OrderItem(Product product, Order orders, int quantity)
        {
            _product = product;
            Price = product.Price;
            Quantity = quantity;
        }

        public Product Product
        {
            get { return _product; }
        }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

     
        public ICollection<Order> Orders { get; set; }

        public decimal LineTotal()
        {
            return Quantity * Price;
        }

        public bool Contains(Product product)
        {
            return Product == product;
        }

        protected override void Validate()
        {
            if (Orders == null)
                AddBrokenRule(OrderBusinessRules.OrderRequired);

            if (Product == null)
                AddBrokenRule(OrderBusinessRules.ProductRequired);

            if (Price < 0)
                AddBrokenRule(OrderBusinessRules.PriceNonNegative);

            if (Quantity > 0)
                AddBrokenRule(OrderBusinessRules.QtyNonNegative);
        }
    }
}
