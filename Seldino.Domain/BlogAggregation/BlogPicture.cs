using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BlogAggregation
{
    public class BlogPicture : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<BlogPost> BlogPosts { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
