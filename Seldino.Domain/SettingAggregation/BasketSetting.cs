using System;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.SettingAggregation
{
    public class BasketSetting : EntityBase
    {
        public bool EmailNotificationEnabled { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
