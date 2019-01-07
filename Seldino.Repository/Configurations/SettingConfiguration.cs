using System.Data;
using Seldino.Domain.SettingAggregation;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Configurations
{
    internal class SettingConfiguration : EntityBaseConfiguration<Setting>
    {
        public SettingConfiguration()
        {
            ToTable("Setting", SchemaConstant.Setting);

            HasOptional(m => m.BannerSetting)
                .WithMany()
                .HasForeignKey(c => c.BannerSettingId);

            HasOptional(m => m.BasicSetting)
                .WithMany()
                .HasForeignKey(c => c.BasicSettingId);

            HasOptional(m => m.BasketSetting)
                .WithMany()
                .HasForeignKey(c => c.BasketSettingId);

            HasOptional(m => m.DiscountSetting)
                .WithMany()
                .HasForeignKey(c => c.DiscountSettingId);

            HasOptional(m => m.DocumentSetting)
                .WithMany()
                .HasForeignKey(c => c.DocumentSettingId);

            HasOptional(m => m.OrderSetting)
               .WithMany()
               .HasForeignKey(c => c.OrderSettingId);

            HasOptional(m => m.ProductSetting)
                .WithMany()
                .HasForeignKey(c => c.ProductSettingId);

            HasOptional(m => m.StoreSetting)
                .WithMany()
                .HasForeignKey(c => c.StoreSettingId);

            HasOptional(m => m.SeoSetting)
                .WithMany()
                .HasForeignKey(c => c.SeoSettingId);
        }
    }

    internal class BannerSettingConfiguration : EntityBaseConfiguration<BannerSetting>
    {
        public BannerSettingConfiguration()
        {
            ToTable("BannerSetting", SchemaConstant.Setting);

            Property(s => s.IsAutoPublished).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
        }
    }

    internal class BasicSettingConfiguration : EntityBaseConfiguration<BasicSetting>
    {
        public BasicSettingConfiguration()
        {
            ToTable("BasicSetting", SchemaConstant.Setting);

            Property(model => model.WebsiteTitle).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsRequired();
            Property(model => model.WebsiteUrl).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsRequired();
        }
    }

    internal class BasketSettingConfiguration : EntityBaseConfiguration<BasketSetting>
    {
        public BasketSettingConfiguration()
        {
            ToTable("BasketSetting", SchemaConstant.Setting);
            Property(model => model.EmailNotificationEnabled).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
        }
    }

    internal class BlogSettingConfiguration : EntityBaseConfiguration<BlogSetting>
    {
        public BlogSettingConfiguration()
        {
            ToTable("BlogSetting", SchemaConstant.Setting);

            Property(s => s.IsCommentAutoPublished).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(s => s.CommentLength).HasColumnType(SqlDbType.Int.ToString()).IsRequired();
            Property(s => s.CommentIntervalTime).HasColumnType(SqlDbType.Int.ToString()).IsRequired();
        }
    }

    internal class DiscountSettingConfiguration : EntityBaseConfiguration<DiscountSetting>
    {
        public DiscountSettingConfiguration()
        {
            ToTable("DiscountSetting", SchemaConstant.Setting);
        }
    }


    internal class DocumentSettingConfiguration : EntityBaseConfiguration<DocumentSetting>
    {
        public DocumentSettingConfiguration()
        {
            ToTable("DocumentSetting", SchemaConstant.Setting);
        }
    }

    internal class OrderSettingConfiguration : EntityBaseConfiguration<OrderSetting>
    {
        public OrderSettingConfiguration()
        {
            ToTable("OrderSetting", SchemaConstant.Setting);

        }
    }

    internal class ProductSettingConfiguration : EntityBaseConfiguration<ProductSetting>
    {
        public ProductSettingConfiguration()
        {
            ToTable("ProductSetting", SchemaConstant.Setting);

            Property(s => s.IsAutoPublished).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(s => s.ImagePrefixAddress).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(300).IsRequired();
            Property(s => s.IsCommentAutoPublished).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(s => s.CommentLength).HasColumnType(SqlDbType.Int.ToString()).IsRequired();
            Property(s => s.CommentIntervalTime).HasColumnType(SqlDbType.Int.ToString()).IsRequired();
        }
    }

    internal class StoreSettingConfiguration : EntityBaseConfiguration<StoreSetting>
    {
        public StoreSettingConfiguration()
        {
            ToTable("StoreSetting", SchemaConstant.Setting);

            Property(s => s.IsAutoPublished).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();

        }
    }

    internal class SeoSettingConfiguration : EntityBaseConfiguration<SeoSetting>
    {
        public SeoSettingConfiguration()
        {
            ToTable("SeoSetting", SchemaConstant.Setting);

            Property(s => s.DefaultMetaDescription).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(200).IsOptional();
            Property(s => s.DefaultMetaKeywords).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(200).IsOptional();
            Property(s => s.DefaultTitle).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsOptional();
        }
    }
}
