using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Domain.ProductAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BasketAggregation.Unauthorized
{
    public class UnauthorizedBasketItem : EntityBase
    {
        private UnauthorizedBasket _basket;

        /// <summary>
        /// Parameterless constructor is required
        /// </summary>
        public UnauthorizedBasketItem()
        {
        }

        public UnauthorizedBasketItem(Product product, UnauthorizedBasket basket, Quantity quantity)
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

        public ICollection<UnauthorizedBasket> UnauthorizedBaskets { get; set; }

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

            if (!UnauthorizedBaskets.Any())
                AddBrokenRule(BasketBusinessRules.BasketRequired);
        }
    }
}
