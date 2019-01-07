using Seldino.Domain.GiftDeskAggregation;
using Seldino.Repository.Infrastructure;
using System.Data;

namespace Seldino.Repository.Configurations
{
    internal class GiftDeskConfiguration : EntityBaseConfiguration<GiftDesk>
    {
        public GiftDeskConfiguration()
        {
            ToTable("GiftDesk", SchemaConstant.GiftDesk);
            Property(e => e.IsPrivate).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();

            HasMany(pt => pt.AcceptedUsers).WithMany(p => p.GiftDesks).Map(m =>
            {
                m.MapLeftKey("GiftDeskId");
                m.MapRightKey("UserId");
                m.ToTable("GiftDesk_AcceptedUser", SchemaConstant.GiftDesk);
            });

            HasMany(pt => pt.Products).WithMany(p => p.GiftDesks).Map(m =>
            {
                m.MapLeftKey("GiftDeskId");
                m.MapRightKey("ProductId");
                m.ToTable("GiftDesk_Product", SchemaConstant.GiftDesk);
            });
        }
    }
}
