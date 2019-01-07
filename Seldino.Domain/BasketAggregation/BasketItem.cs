using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Domain.ProductAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BasketAggregation
{
    public class BasketItem : EntityBase
    {
        private Basket _basket;

        /// <summary>
        /// Parameterless constructor is required
        /// </summary>
        public BasketItem()
        {
        }

        public BasketItem(Product product, Basket basket, Quantity quantity)
        {
            Product = product;
            _basket = basket;
            Quantity = quantity;
            CreationDate = DateTime.Now; //ToDo
            LastUpdateDate = DateTime.Now; //ToDo
        }

        public decimal LineTotal()
        {
            return Product.Price * Quantity.Value;
        }


        public Quantity Quantity { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public ICollection<Basket> Baskets { get; set; }
        
        public bool Contains(Product product)
        {
            return Product == product;
        }

        public void IncreaseItemQtyBy(Quantity quantity)
        {
            Quantity = Quantity.Add(quantity);
        }

        public void ChangeItemQtyTo(Quantity quantity)
        {
            Quantity = quantity;
        }

        protected override void Validate()
        {
            if (Product == null)
                AddBrokenRule(BasketBusinessRules.ProductRequired);

            if (!Baskets.Any())
                AddBrokenRule(BasketBusinessRules.BasketRequired);
        }
    }
}
