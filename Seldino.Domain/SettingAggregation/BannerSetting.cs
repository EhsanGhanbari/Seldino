using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.SettingAggregation
{
    public class BannerSetting : EntityBase
    {
        public bool IsAutoPublished { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
