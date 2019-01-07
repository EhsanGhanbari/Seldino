using System.Data;
using Seldino.Domain.ShippingAggregation;
using Seldino.Repository.Infrastructure;
using System.Data.Entity.ModelConfiguration;

namespace Seldino.Repository.Configurations
{
    internal class DeliveryOptionConfiguration : EntityBaseConfiguration<DeliveryOption>
    {
        public DeliveryOptionConfiguration()
        {
            ToTable("DeliveryOption", SchemaConstant.Shipping);
            Property(p => p.Cost).HasColumnType(SqlDbType.Decimal.ToString()).HasPrecision(18, 2).IsOptional();
            Property(e => e.DeliveryTime).HasColumnType(SqlDbType.TinyInt.ToString()).IsOptional();
            Property(p => p.FreeDeliveryThreshold).HasColumnType(SqlDbType.Decimal.ToString()).HasPrecision(18, 2).IsOptional();

            Property(p => p.ShippingServiceId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(t => t.ShippingService).WithMany().HasForeignKey(pb => pb.ShippingServiceId).WillCascadeOnDelete(false);
        }
    }

    internal class ShippingServiceConfiguration : EntityBaseConfiguration<ShippingService>
    {
        public ShippingServiceConfiguration()
        {
            ToTable("ShippingService", SchemaConstant.Shipping);
            Property(p => p.Code).HasColumnType(SqlDbType.NVarChar.ToString()).IsOptional();
            Property(p => p.Description).HasColumnType(SqlDbType.NVarChar.ToString()).IsOptional();

            Property(p => p.CourierId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(t => t.Courier).WithMany().HasForeignKey(pb => pb.CourierId).WillCascadeOnDelete(false);
        }
    }

    internal class CourierConfiguration : EntityBaseConfiguration<Courier>
    {
        public CourierConfiguration()
        {
            ToTable("Courier", SchemaConstant.Shipping);
            Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsOptional();
        }
    }
}
