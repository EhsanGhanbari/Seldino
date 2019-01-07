using Seldino.Domain.MembershipAggregation;
using Seldino.Repository.Infrastructure;
using System.Data;

namespace Seldino.Repository.Configurations
{
    internal class UserConfiguration : EntityBaseConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User", SchemaConstant.Membership);

            Property(u => u.Email).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(80);
            Property(u => u.Password).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(100);
            Property(e => e.IsActive).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();

            Property(u => u.ProfileId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(u => u.Profile).WithMany().HasForeignKey(p => p.ProfileId).WillCascadeOnDelete(false);

            Property(u => u.RoleName).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(50).IsRequired();
            HasRequired(u => u.Role).WithMany().HasForeignKey(p => p.RoleName).WillCascadeOnDelete(false);

            Property(u => u.GiftDeskId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(u => u.GiftDesk).WithMany().HasForeignKey(p => p.GiftDeskId).WillCascadeOnDelete(false);

            HasMany(u => u.Banners).WithMany(p => p.Users).Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("BannerId");
                m.ToTable("User_banner", SchemaConstant.Membership);
            });

            HasMany(u => u.Stores).WithMany(p => p.Users).Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("StoreId");
                m.ToTable("User_Store", SchemaConstant.Membership);
            });

            HasMany(u => u.BlogComments).WithMany(p => p.Users).Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("BlogCommentId");
                m.ToTable("User_BlogComment", SchemaConstant.Membership);
            });

            HasMany(u => u.Messages).WithMany(p => p.Users).Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("MessageId");
                m.ToTable("User_Message", SchemaConstant.Membership);
            });

            HasMany(u => u.Products).WithMany(p => p.Users).Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("ProductId");
                m.ToTable("User_Product", SchemaConstant.Membership);
            });

            HasMany(u => u.Favorites).WithMany(p => p.Users).Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("FavoriteId");
                m.ToTable("User_Favorite", SchemaConstant.Membership);
            });

            HasMany(u => u.Locations).WithMany(p => p.Users).Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("LocationId");
                m.ToTable("User_Location", SchemaConstant.Membership);
            });

            HasMany(u => u.Payments).WithMany(p => p.Users).Map(m =>
            {
                m.MapLeftKey("UserId");
                m.MapRightKey("PaymentId");
                m.ToTable("User_Payment", SchemaConstant.Membership);
            });
        }
    }

    internal class ProfileConfiguration : EntityBaseConfiguration<Profile>
    {
        public ProfileConfiguration()
        {
            ToTable("Profile", SchemaConstant.Membership);
            Property(u => u.FirstName).HasColumnType(SqlDbType.NVarChar.ToString()).IsOptional().HasMaxLength(50);
            Property(u => u.LastName).HasColumnType(SqlDbType.NVarChar.ToString()).IsOptional().HasMaxLength(50);
            Property(u => u.CellPhone).HasColumnType(SqlDbType.NVarChar.ToString()).IsOptional().HasMaxLength(50);
            Property(e => e.BirthDate).HasColumnType(SqlDbType.DateTime.ToString()).IsOptional();

            Property(d => d.AvatarId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasOptional(d => d.Avatar).WithMany().HasForeignKey(p => p.AvatarId).WillCascadeOnDelete(false);
        }
    }

    internal class RoleConfiguration : ValueObjectBaseConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("Role", SchemaConstant.Membership);
            HasKey(c => c.Name).Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
            Property(r => r.Description).HasColumnType(SqlDbType.NVarChar.ToString()).IsOptional().HasMaxLength(200);
            Property(r => r.IsDefault).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();

            HasMany(u => u.Operations).WithMany(p => p.Roles).Map(m =>
            {
                m.MapLeftKey("RoleName");
                m.MapRightKey("OperationId");
                m.ToTable("Role_Operation", SchemaConstant.Membership);
            });

            HasMany(u => u.Permisions).WithMany(p => p.Role).Map(m =>
            {
                m.MapLeftKey("RoleName");
                m.MapRightKey("PermisionId");
                m.ToTable("Role_Permision", SchemaConstant.Membership);
            });
        }
    }

    internal class PermisionConfiguration : EntityBaseConfiguration<Permision>
    {
        public PermisionConfiguration()
        {
            ToTable("Permision", SchemaConstant.Membership);

            Property(d => d.OperationId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsOptional();
            HasRequired(d => d.Operation).WithMany().HasForeignKey(p => p.OperationId).WillCascadeOnDelete(false);
        }
    }

    internal class OperationConfiguration : EntityBaseConfiguration<Operation>
    {
        public OperationConfiguration()
        {
            ToTable("Operation", SchemaConstant.Membership);
            Property(d => d.Name).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(500).IsRequired();
        }
    }

    internal class ProfileAvatarConfiguration : EntityBaseConfiguration<ProfileAvatar>
    {
        public ProfileAvatarConfiguration()
        {
            ToTable("ProfileAvatar", SchemaConstant.Membership);
            Property(p => p.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(50);
            Property(p => p.Address).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(200);
        }
    }

    internal class FavoriteConfiguration : EntityBaseConfiguration<Favorite>
    {
        public FavoriteConfiguration()
        {
            ToTable("Favorite", SchemaConstant.Membership);
            Property(f => f.Description).IsOptional().HasMaxLength(100);

            HasMany(pb => pb.Products).WithMany(p => p.Favorites).Map(m =>
            {
                m.MapLeftKey("FavoriteId");
                m.MapRightKey("ProductId");
                m.ToTable("Favorite_Product", SchemaConstant.Membership);
            });

            HasMany(pb => pb.Stores).WithMany(p => p.Favorites).Map(m =>
            {
                m.MapLeftKey("FavoriteId");
                m.MapRightKey("StoreId");
                m.ToTable("Favorite_Store", SchemaConstant.Membership);
            });
        }
    }
}
