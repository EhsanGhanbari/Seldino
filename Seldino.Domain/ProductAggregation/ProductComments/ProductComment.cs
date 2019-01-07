using System;
using System.Collections.Generic;
using Seldino.Domain.MembershipAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.ProductAggregation.ProductComments
{
    public class ProductComment : EntityBase, IAggregateRoot
    {
        private ICollection<ProductComment> _productComments = new List<ProductComment>();
        private ICollection<Product> _product = new List<Product>();

        public string Body { get; set; }

        public Guid? ParentId { get; set; }

        public virtual ICollection<ProductComment> ProductComments
        {
            get { return _productComments ?? (_productComments = new List<ProductComment>()); }
            set { _productComments = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return _product ?? (_product = new List<Product>()); }
            set { _product = value; }
        }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
