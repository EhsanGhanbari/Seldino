using System;
using Seldino.Domain.ProductAggregation;
using Seldino.Infrastructure.Domain;
using System.Collections.Generic;
using System.Linq;
using Seldino.Domain.MembershipAggregation;

namespace Seldino.Domain.BasketAggregation
{
    public class Basket : EntityBase, IAggregateRoot
    {
        private ICollection<BasketItem> _basketItems;

        public Basket()
        {
            _basketItems = new List<BasketItem>();
        }

        public virtual ICollection<BasketItem> BasketItems
        {
            get { return _basketItems ?? (_basketItems = new List<BasketItem>()); }
            set { _basketItems = value; }
        }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
       

        public int NumberOfItems
        {
            get { return _basketItems.Sum(i => i.Quantity.Value); }
        }

        public decimal ItemsTotal
        {
            get { return _basketItems.Sum(i => i.Quantity.Value * i.Product.Price); }
        }

        public void AddBasketItem(Product product)
        {
            if (BasketContainsAnItemFor(product))
                GetItemFor(product).IncreaseItemQtyBy(new Quantity(1));
            else
                _basketItems.Add(BasketItemFactory.CreateItemFor(product, this));
        }

        private BasketItem GetItemFor(Product product)
        {
            return _basketItems.FirstOrDefault(i => i.Contains(product));
        }

        private bool BasketContainsAnItemFor(Product product)
        {
            return _basketItems.Any(i => i.Contains(product));
        }

        public void Remove(Product product)
        {
            if (BasketContainsAnItemFor(product))
            {
                _basketItems.Remove(GetItemFor(product));
            }
        }

        public void ChangeQuantityOfProduct(Quantity quantity, Product product)
        {
            if (BasketContainsAnItemFor(product))
            {
                if (quantity.IsZero())
                {
                    Remove(product);
                }
                else
                {
                    GetItemFor(product).ChangeItemQtyTo(quantity);
                }
            }
        }

        public int NumberOfItemsInBasket()
        {
            return _basketItems.Sum(i => i.Quantity.Value);
        }

        public IEnumerable<BasketItem> Items()
        {
            return _basketItems;
        }

        protected override void Validate()
        {
            foreach (var item in Items())
            {
                if (item.GetBrokenRules().Any())
                    AddBrokenRule(BasketBusinessRules.ItemInvalid);
            }
        }
    }
}
