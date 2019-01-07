using Seldino.Infrastructure.Domain;
using System;

namespace Seldino.Domain.DocumentAggregation
{
    public class SocialMediaOption : ValueObjectBase
    {
        public string Name { get; set; }
        public byte[] Icon { get; set; }
     
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
