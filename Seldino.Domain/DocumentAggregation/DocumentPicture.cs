using System.Collections.Generic;
using Seldino.Infrastructure.Domain;
using System;

namespace Seldino.Domain.DocumentAggregation
{
    public class DocumentPicture : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<About> Abouts { get; set; }
        public ICollection<Guide> Guides { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
