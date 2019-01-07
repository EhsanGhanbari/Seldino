using System;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.SettingAggregation
{
    public class StoreSetting : EntityBase
    {
        public bool IsAutoPublished { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
