using System.Data;
using Seldino.Domain.BasketAggregation;
using Seldino.Domain.BasketAggregation.Unauthorized;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Configurations
{
    internal class BasketConfiguration : EntityBaseConfiguration<Basket>
    {
        public BasketConfiguration()
        {
            ToTable("Basket", SchemaConstant.Basket);

            Property(u => u.UserId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(u => u.User).WithMany().HasForeignKey(p => p.UserId).WillCascadeOnDelete(false);

            HasMany(pb => pb.BasketItems).WithMany(p => p.Baskets).Map(m =>
            {
                m.MapLeftKey("BasketId");
                m.MapRightKey("BasketItemId");
                m.ToTable("Basket_BasketItem", SchemaConstant.Basket);
            });
        }
    }

    internal class BasketItemConfiguration : EntityBaseConfiguration<BasketItem>
    {
        public BasketItemConfiguration()
        {
            ToTable("BasketItem", SchemaConstant.Basket);

            Property(b => b.Quantity.Value).HasColumnName("Quantity").HasColumnType(SqlDbType.Int.ToString()).IsRequired();

            Property(b => b.ProductId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasRequired(b => b.Product).WithMany().HasForeignKey(p => p.ProductId).WillCascadeOnDelete(false);
        }
    }

    internal class UnauthorizedBasketConfiguration : EntityBaseConfiguration<UnauthorizedBasket>
    {
        public UnauthorizedBasketConfiguration()
        {
            ToTable("UnauthorizedBasket", SchemaConstant.Basket);

            HasMany(pb => pb.BasketItems).WithMany(p => p.UnauthorizedBaskets).Map(m =>
            {
                m.MapLeftKey("UnauthorizedBasketId");
                m.MapRightKey("BasketItemId");
                m.ToTable("UnauthorizedBasket_BasketItem", SchemaConstant.Basket);
            });
        }
    }

    internal class UnauthorizedBasketItemConfigucation : EntityBaseConfiguration<UnauthorizedBasketItem>
    {
        public UnauthorizedBasketItemConfigucation()
        {
            ToTable("UnauthorizedBasketItem", SchemaConstant.Basket);

            Property(b => b.Quantity.Value).HasColumnName("Quantity").HasColumnType(SqlDbType.Int.ToString()).IsRequired();

            Property(b => b.ProductId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasRequired(b => b.Product).WithMany().HasForeignKey(p => p.ProductId).WillCascadeOnDelete(false);
        }
    }
}
