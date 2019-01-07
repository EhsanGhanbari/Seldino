using System.Data;
using Seldino.Domain.StoreAggregation;
using Seldino.Domain.StoreAggregation.StoreComments;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Configurations
{
    internal class StoreConfiguration : EntityBaseConfiguration<Store>
    {
        public StoreConfiguration()
        {
            ToTable("Store", SchemaConstant.Store);
            Property(s => s.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(100);
            Property(s => s.IsInactive).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(u => u.Phone).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);

            Property(d => d.DocumentId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(d => d.Document).WithMany().HasForeignKey(p => p.DocumentId).WillCascadeOnDelete(false);

            Property(d => d.LocationId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasRequired(d => d.Location).WithMany().HasForeignKey(p => p.LocationId).WillCascadeOnDelete(false);

            HasMany(u => u.Products).WithMany(c => c.Stores).Map(m =>
            {
                m.MapLeftKey("StoreId");
                m.MapRightKey("ProductId");
                m.ToTable("Store_Product", SchemaConstant.Store);
            });

            HasMany(u => u.Pictures).WithMany(c => c.Stores).Map(m =>
            {
                m.MapLeftKey("StoreId");
                m.MapRightKey("PictureId");
                m.ToTable("Store_Picture", SchemaConstant.Store);
            });

            HasMany(u => u.StoreComments).WithMany(c => c.Stores).Map(m =>
            {
                m.MapLeftKey("StoreId");
                m.MapRightKey("StoreCommentId");
                m.ToTable("Store_Comment", SchemaConstant.Store);
            });

            HasMany(u => u.SupportedRegions).WithMany(c => c.SupportedStores).Map(m =>
            {
                m.MapLeftKey("StoreId");
                m.MapRightKey("RegionName");
                m.ToTable("Store_SupprtedRegion", SchemaConstant.Store);
            });

            HasMany(u => u.SupportedAreas).WithMany(c => c.SupportedStores).Map(m =>
            {
                m.MapLeftKey("StoreId");
                m.MapRightKey("AreaName");
                m.ToTable("Store_SupprtedArea", SchemaConstant.Store);
            });
        }
    }

    internal class StorePictureConfiguration : EntityBaseConfiguration<StorePicture>
    {
        public StorePictureConfiguration()
        {
            ToTable("StorePicture", SchemaConstant.Store);
            Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
            Property(p => p.Address).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
        }
    }

    internal class StoreCommentConfiguration : EntityBaseConfiguration<StoreComment>
    {
        public StoreCommentConfiguration()
        {
            ToTable("StoreComment", SchemaConstant.Store);
            Property(p => p.Body).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(150);

            HasMany(p => p.ProductComments)
                .WithOptional()
                .HasForeignKey(pc => pc.ParentId)
                .WillCascadeOnDelete(false);
        }
    }
}
