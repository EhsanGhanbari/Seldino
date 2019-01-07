using System.Collections.Generic;
using Seldino.Infrastructure.Domain;
using System;

namespace Seldino.Domain.DocumentAggregation
{
    public class Guide : EntityBase
    {
        public string Body { get; set; }
        public virtual ICollection<DocumentPicture> DocumentPictures { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

