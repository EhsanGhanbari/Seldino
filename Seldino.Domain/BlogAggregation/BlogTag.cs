using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BlogAggregation
{
    public class BlogTag : ValueObjectBase
    {
        public string Name { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
        public ICollection<BlogCategory> BlogCategories { get; set; } 

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
