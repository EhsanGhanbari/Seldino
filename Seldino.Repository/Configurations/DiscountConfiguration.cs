using System.Data;
using Seldino.Domain.DiscountAggregation;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Configurations
{
    internal class DiscountConfiguration : EntityBaseConfiguration<Discount>
    {
        public DiscountConfiguration()
        {
            ToTable("Discount", SchemaConstant.Discount);
            Property(d => d.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
            Property(d => d.StartDate).HasColumnType(SqlDbType.DateTime.ToString()).IsOptional();
            Property(d => d.EndDate).HasColumnType(SqlDbType.DateTime.ToString()).IsOptional();
            Property(d => d.Amount).HasColumnType(SqlDbType.Decimal.ToString()).IsOptional();
            Property(d => d.DiscountLimitation).HasColumnType(SqlDbType.TinyInt.ToString()).IsRequired();
            Property(d => d.DiscountType).HasColumnType(SqlDbType.TinyInt.ToString()).IsRequired();
            Property(d => d.Percentage).HasColumnType(SqlDbType.Decimal.ToString()).IsOptional();
            Property(p => p.Stopped).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();

            HasMany(p => p.Products).WithMany(d => d.Discounts).Map(m =>
            {
                m.MapLeftKey("DiscountId");
                m.MapRightKey("ProductId");
                m.ToTable("Discount_Product", SchemaConstant.Discount);
            });

            HasMany(s => s.Stores).WithMany(d => d.Discounts).Map(m =>
            {
                m.MapLeftKey("DiscountId");
                m.MapRightKey("StoreId");
                m.ToTable("Discount_Store", SchemaConstant.Discount);
            });

            HasMany(s => s.ProductCategories).WithMany(d => d.Discounts).Map(m =>
            {
                m.MapLeftKey("DiscountId");
                m.MapRightKey("CategoryName");
                m.ToTable("Discount_ProductCategory", SchemaConstant.Discount);
            });

            HasMany(s => s.ProductBrands).WithMany(d => d.Discounts).Map(m =>
            {
                m.MapLeftKey("DiscountId");
                m.MapRightKey("BrandName");
                m.ToTable("Discount_ProductBrand", SchemaConstant.Discount);
            });

            HasMany(s => s.ProductTags).WithMany(d => d.Discounts).Map(m =>
            {
                m.MapLeftKey("DiscountId");
                m.MapRightKey("TagName");
                m.ToTable("Discount_ProductTag", SchemaConstant.Discount);
            });
        }
    }
}
