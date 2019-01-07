using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.SettingAggregation
{
    public class BasicSetting : EntityBase
    {
        #region Website
        public string WebsiteTitle { get; set; }

        public string WebsiteUrl { get; set; }
        #endregion

        protected override void Validate()
        {
        }
    }
}
