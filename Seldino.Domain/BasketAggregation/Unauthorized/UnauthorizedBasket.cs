using System;
using System.Collections.Generic;
using System.Linq;
using Seldino.Domain.ProductAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BasketAggregation.Unauthorized
{
    public class UnauthorizedBasket : EntityBase, IAggregateRoot
    {
        public Guid CookieId { get; set; }

        private ICollection<UnauthorizedBasketItem> _basketItems;

        public UnauthorizedBasket()
        {
            _basketItems = new List<UnauthorizedBasketItem>();
        }

        public virtual ICollection<UnauthorizedBasketItem> BasketItems
        {
            get { return _basketItems ?? (_basketItems = new List<UnauthorizedBasketItem>()); }
            set { _basketItems = value; }
        }

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
                _basketItems.Add(UnauthorizedBasketItemFactory.CreateItemFor(product, this));
        }

        private UnauthorizedBasketItem GetItemFor(Product product)
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

        public IEnumerable<UnauthorizedBasketItem> Items()
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
