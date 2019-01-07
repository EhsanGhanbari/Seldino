using Seldino.Infrastructure.Domain;
using System;
using System.Collections.Generic;

namespace Seldino.Domain.DocumentAggregation
{
    public class SocialMedia : EntityBase
    {
        public string Url { get; set; }
        public string SocialMediaOptionName { get; set; }
        public virtual SocialMediaOption SocialMediaOption { get; set; }
        public virtual ICollection<Document> Documents { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
