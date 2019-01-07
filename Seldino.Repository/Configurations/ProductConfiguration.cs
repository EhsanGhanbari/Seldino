using Seldino.Domain.ProductAggregation;
using Seldino.Domain.ProductAggregation.ProductComments;
using Seldino.Domain.ProductAggregation.ProductRatings;
using Seldino.Repository.Infrastructure;
using System.Data;

namespace Seldino.Repository.Configurations
{
    internal class ProductConfiguration : EntityBaseConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Product", SchemaConstant.Product);
            Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
            Property(p => p.Slug).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
            Property(p => p.OriginalName).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(80);
            Property(p => p.IsInactive).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(p => p.IsUnavailable).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(p => p.Description).HasMaxLength(1000).IsOptional();
            Property(p => p.Price).HasColumnType(SqlDbType.Decimal.ToString()).HasPrecision(18, 2).IsRequired();
            Property(p => p.OldPrice).HasColumnType(SqlDbType.Decimal.ToString()).HasPrecision(18, 2).IsOptional();
            Property(p => p.DollarPrice).HasColumnType(SqlDbType.Decimal.ToString()).HasPrecision(18, 2).IsOptional();
            Property(p => p.OldDollarPrice).HasColumnType(SqlDbType.Decimal.ToString()).HasPrecision(18, 2).IsOptional();
            Property(p => p.SerializedColors).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(500).IsOptional();
            Property(p => p.SerializedSizes).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(500).IsOptional();
            Property(p => p.SerializedTags).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(500).IsOptional();
            Property(p => p.MetKeywords).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(500).IsOptional();

            Property(p => p.VisitCount).HasColumnType(SqlDbType.Int.ToString()).IsRequired();

            Property(p => p.Category).HasMaxLength(50).IsRequired();
            HasRequired(t => t.ProductCategory).WithMany().HasForeignKey(pc => pc.Category).WillCascadeOnDelete(false);

            Property(p => p.Brand).HasMaxLength(50).IsOptional();
            HasOptional(t => t.ProductBrand).WithMany().HasForeignKey(pb => pb.Brand).WillCascadeOnDelete(false);

            Property(p => p.SpecialStateId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(t => t.ProductSpecialState).WithMany().HasForeignKey(pb => pb.SpecialStateId).WillCascadeOnDelete(false);

            Property(e => e.IsUnavailable).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(e => e.NotExist).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(e => e.IsInSpecialState).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();

            HasMany(pt => pt.ProductTags).WithMany(p => p.Products).Map(m =>
            {
                m.MapLeftKey("ProductId");
                m.MapRightKey("TagName");
                m.ToTable("Product_ProductTag", SchemaConstant.Product);
            });

            HasMany(pp => pp.ProductPictures).WithMany(p => p.Products).Map(m =>
            {
                m.MapLeftKey("ProductId");
                m.MapRightKey("ProductPictureId");
                m.ToTable("Product_ProductPicture", SchemaConstant.Product);
            });

            HasMany(pp => pp.ProductColors).WithMany(p => p.Products).Map(m =>
            {
                m.MapLeftKey("ProductId");
                m.MapRightKey("ColorName");
                m.ToTable("Product_ProductColor", SchemaConstant.Product);
            });

            HasMany(ps => ps.ProductSizes).WithMany(p => p.Products).Map(m =>
            {
                m.MapLeftKey("ProductId");
                m.MapRightKey("SizeName");
                m.ToTable("Product_ProductSize", SchemaConstant.Product);
            });

            HasMany(pt => pt.ProductAttributes).WithMany(p => p.Products).Map(m =>
            {
                m.MapLeftKey("ProductId");
                m.MapRightKey("AttributeId");
                m.ToTable("Product_ProductAttribute", SchemaConstant.Product);
            });

            HasMany(pao => pao.ProductAttributeOptions).WithMany(p => p.Products).Map(m =>
            {
                m.MapLeftKey("ProductId");
                m.MapRightKey("OptionName");
                m.ToTable("Product_ProductAttributeOption", SchemaConstant.Product);
            });

            HasMany(pc => pc.ProductComments).WithMany(p => p.Products).Map(m =>
            {
                m.MapLeftKey("ProductId");
                m.MapRightKey("ProductCommentId");
                m.ToTable("Product_ProductComment", SchemaConstant.Product);
            });
        }
    }

    internal class ProductAttributeConfiguration : EntityBaseConfiguration<ProductAttribute>
    {
        public ProductAttributeConfiguration()
        {
            ToTable("ProductAttribute", SchemaConstant.Product);
            Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);

            HasMany(pc => pc.AttributeOptions).WithMany(p => p.Attributes).Map(m =>
            {
                m.MapLeftKey("AttributeId");
                m.MapRightKey("OptionName");
                m.ToTable("ProductAttribute_AttributeOption", SchemaConstant.Product);
            });
        }
    }

    internal class ProductAttributeOptionConfiguration : ValueObjectBaseConfiguration<ProductAttributeOption>
    {
        public ProductAttributeOptionConfiguration()
        {
            ToTable("ProductAttributeOption", SchemaConstant.Product);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
        }
    }

    internal class ProductBrandConficuration : ValueObjectBaseConfiguration<ProductBrand>
    {
        public ProductBrandConficuration()
        {
            ToTable("ProductBrand", SchemaConstant.Product);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);

            Property(d => d.IconId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(d => d.Icon).WithMany().HasForeignKey(p => p.IconId).WillCascadeOnDelete(false);
        }
    }

    internal class ProductCategoryConfiguration : ValueObjectBaseConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration()
        {
            ToTable("ProductCategory", SchemaConstant.Product);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);

            Property(d => d.IconId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(d => d.Icon).WithMany().HasForeignKey(p => p.IconId).WillCascadeOnDelete(false);

            HasKey(p => p.Name).Property(p => p.ParentCategory).HasColumnType(SqlDbType.NVarChar.ToString()).IsOptional().HasMaxLength(50);

            HasMany(p => p.ProductCategories)
             .WithOptional()
             .HasForeignKey(pc => pc.ParentCategory)
             .WillCascadeOnDelete(false);

            HasMany(pc => pc.ProductTags).WithMany(p => p.ProductCategories).Map(m =>
            {
                m.MapLeftKey("CategoryName");
                m.MapRightKey("TagName");
                m.ToTable("ProductCategory_ProductTag", SchemaConstant.Product);
            });

            HasMany(pc => pc.ProductBrands).WithMany(p => p.ProductCategories).Map(m =>
            {
                m.MapLeftKey("CategoryName");
                m.MapRightKey("BrandName");
                m.ToTable("ProductCategory_ProductBrand", SchemaConstant.Product);
            });

            HasMany(pc => pc.ProductAttributes).WithMany(p => p.Categories).Map(m =>
            {
                m.MapLeftKey("CategoryName");
                m.MapRightKey("AttributeId");
                m.ToTable("ProductCategory_ProductAttribute", SchemaConstant.Product);
            });
        }
    }

    internal class ProductColorConfiguration : ValueObjectBaseConfiguration<ProductColor>
    {
        public ProductColorConfiguration()
        {
            ToTable("ProductColor", SchemaConstant.Product);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
            Property(p => p.Code).IsOptional();

            Property(d => d.IconId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(d => d.Icon).WithMany().HasForeignKey(p => p.IconId).WillCascadeOnDelete(false);
        }
    }

    internal class ProductTagConfiguration : ValueObjectBaseConfiguration<ProductTag>
    {
        public ProductTagConfiguration()
        {
            ToTable("ProductTag", SchemaConstant.Product);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);

            Property(d => d.IconId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(d => d.Icon).WithMany().HasForeignKey(p => p.IconId).WillCascadeOnDelete(false);

            HasMany(pc => pc.ProductSizes).WithMany(p => p.ProductTags).Map(m =>
            {
                m.MapLeftKey("TagName");
                m.MapRightKey("SizeName");
                m.ToTable("ProductTag_ProductSize", SchemaConstant.Product);
            });
        }
    }

    internal class ProductSizeConfiguration : ValueObjectBaseConfiguration<ProductSize>
    {
        public ProductSizeConfiguration()
        {
            ToTable("ProductSize", SchemaConstant.Product);
            HasKey(p => p.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
        }
    }

    internal class ProductSpecialStateConfiguration : EntityBaseConfiguration<ProductSpecialState>
    {
        public ProductSpecialStateConfiguration()
        {
            ToTable("ProductSpecialState", SchemaConstant.Product);
            Property(e => e.StartDate).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
            Property(e => e.EndDate).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
        }
    }

    internal class ProductPictureConfiguration : EntityBaseConfiguration<ProductPicture>
    {
        public ProductPictureConfiguration()
        {
            ToTable("ProductPicture", SchemaConstant.Product);
            Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
            Property(p => p.Address).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
        }
    }

    internal class ProductCommentConfiguration : EntityBaseConfiguration<ProductComment>
    {
        public ProductCommentConfiguration()
        {
            ToTable("ProductComment", SchemaConstant.Product);
            Property(p => p.Body).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(150);

            Property(d => d.UserId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(d => d.User).WithMany().HasForeignKey(p => p.UserId).WillCascadeOnDelete(false);

            HasMany(p => p.ProductComments)
                .WithOptional()
                .HasForeignKey(pc => pc.ParentId)
                .WillCascadeOnDelete(false);
        }
    }

    internal class ProductRatingConfiguration : EntityBaseConfiguration<ProductRating>
    {
        public ProductRatingConfiguration()
        {
            ToTable("ProductRating", SchemaConstant.Product);

            Property(d => d.ProductId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasRequired(d => d.Product).WithMany().HasForeignKey(p => p.ProductId).WillCascadeOnDelete(false);

            Property(d => d.UserId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasRequired(d => d.User).WithMany().HasForeignKey(p => p.UserId).WillCascadeOnDelete(false);
        }
    }

    internal class ProductIconConfiguration : EntityBaseConfiguration<ProductIcon>
    {
        public ProductIconConfiguration()
        {
            ToTable("ProductIcon", SchemaConstant.Product);
            Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
            Property(p => p.Address).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
        }
    }
}