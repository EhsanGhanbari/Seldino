using Seldino.Infrastructure.Domain;
using System;

namespace Seldino.Domain.BannerAggregation
{
    public class BannerPicture : EntityBase
    {
        public string Name { get; set; }

        public string Address { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
