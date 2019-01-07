using System;
using System.Collections.Generic;
using Seldino.Domain.MembershipAggregation;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BlogAggregation.BlogComments
{
    public class BlogComment : EntityBase, IAggregateRoot
    {
        public string Body { get; set; }
        public Guid? ParentId { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
        public ICollection<BlogComment> BlogComments { get; set; }
        public ICollection<User> Users { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
