using System.Data;
using Seldino.Domain.BannerAggregation;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Configurations
{
    internal class BannerConfiguration : EntityBaseConfiguration<Banner>
    {
        public BannerConfiguration()
        {
            ToTable("Banner", SchemaConstant.Banner);
            Property(b => b.StartDate).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
            Property(b => b.EndDate).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
            Property(b => b.IsActive).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(b => b.BannerType).HasColumnType(SqlDbType.TinyInt.ToString()).IsRequired();
            Property(b => b.Fee).HasColumnType(SqlDbType.Decimal.ToString()).IsRequired();
            Property(e => e.IsConfirmed).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(p => p.Url).HasColumnType(SqlDbType.NVarChar.ToString()).IsOptional().HasMaxLength(200);
            Property(p => p.Caption).HasColumnType(SqlDbType.NVarChar.ToString()).IsOptional().HasMaxLength(50);

            Property(d => d.PictureId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
            HasRequired(d => d.Picture).WithMany().HasForeignKey(p => p.PictureId).WillCascadeOnDelete(false);
        }
    }

    internal class BannerPictureConfiguration : EntityBaseConfiguration<BannerPicture>
    {
        public BannerPictureConfiguration()
        {
            ToTable("BannerPicture", "Banner");
            Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
            Property(p => p.Address).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
        }
    }
}
