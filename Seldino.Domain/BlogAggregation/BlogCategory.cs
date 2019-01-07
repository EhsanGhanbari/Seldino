using System;
using System.Collections.Generic;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.BlogAggregation
{
    public class BlogCategory : ValueObjectBase
    {
        public string Name { get; set; }
        public virtual ICollection<BlogTag> BlogTags { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
