using System;
using Seldino.Infrastructure.Domain;

namespace Seldino.Domain.SettingAggregation
{
    public class Setting : EntityBase, IAggregateRoot
    {
        public Guid? BannerSettingId { get; set; }

        public virtual BannerSetting BannerSetting { get; set; }

        public Guid? BasicSettingId { get; set; }

        public virtual BasicSetting BasicSetting { get; set; }

        public Guid? BasketSettingId { get; set; }

        public virtual BasketSetting BasketSetting { get; set; }

        public Guid? BlogSettingId { get; set; }

        public virtual BlogSetting BlogSetting { get; set; }

        public Guid? DiscountSettingId { get; set; }

        public virtual DiscountSetting DiscountSetting { get; set; }

        public Guid? DocumentSettingId { get; set; }

        public virtual DocumentSetting DocumentSetting { get; set; }

        public Guid? OrderSettingId { get; set; }

        public OrderSetting OrderSetting { get; set; }

        public Guid? ProductSettingId { get; set; }

        public virtual ProductSetting ProductSetting { get; set; }

        public Guid? StoreSettingId { get; set; }

        public StoreSetting StoreSetting { get; set; }

        public Guid? SeoSettingId { get; set; }

        public virtual SeoSetting SeoSetting { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
