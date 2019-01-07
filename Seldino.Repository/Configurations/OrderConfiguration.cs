using System.Data;
using Seldino.Domain.OrderAggregation;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Configurations
{
    internal class OrderConfiguration : EntityBaseConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Order", SchemaConstant.Order);
            Property(p => p.ShippingCharge).HasColumnType(SqlDbType.Decimal.ToString()).IsRequired();

            Property(d => d.ShippingServiceId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasRequired(d => d.ShippingService).WithMany().HasForeignKey(p => p.ShippingServiceId).WillCascadeOnDelete(false);

            Property(d => d.LocationId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasRequired(d => d.Location).WithMany().HasForeignKey(p => p.LocationId).WillCascadeOnDelete(false);

            Property(d => d.PaymentId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasRequired(d => d.Payment).WithMany().HasForeignKey(p => p.PaymentId).WillCascadeOnDelete(false);

            HasMany(pt => pt.Items).WithMany(p => p.Orders).Map(m =>
            {
                m.MapLeftKey("OrderId");
                m.MapRightKey("OrderItemId");
                m.ToTable("Order_OrdetItem", SchemaConstant.Order);
            });
        }
    }

    internal class OrderItemConfiguration : EntityBaseConfiguration<OrderItem>
    {
        public OrderItemConfiguration()
        {
            ToTable("OrderItem", SchemaConstant.Order);
            Property(s => s.Quantity).HasColumnType(SqlDbType.Int.ToString()).IsRequired();
            Property(s => s.Price).HasColumnType(SqlDbType.Decimal.ToString()).IsRequired();
        }
    }
}
