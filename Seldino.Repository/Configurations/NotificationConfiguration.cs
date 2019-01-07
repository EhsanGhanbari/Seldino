using Seldino.Domain.NotificationAggregation;
using Seldino.Repository.Infrastructure;
using System.Data;

namespace Seldino.Repository.Configurations
{
    internal class NotificationConfiguration : EntityBaseConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            ToTable("Notification", SchemaConstant.Notification);
            Property(m => m.Title).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsOptional();
            Property(m => m.Body).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(500).IsOptional();
            Property(e => e.IsActive).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
        }
    }

    internal class MessageConfiguration : EntityBaseConfiguration<Message>
    {
        public MessageConfiguration()
        {
            ToTable("Message", SchemaConstant.Notification);
            Property(m => m.Name).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(50).IsOptional();
            Property(m => m.Title).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(100).IsRequired();
            Property(m => m.Body).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(500).IsRequired();
            Property(m => m.NotificationMessageType).HasColumnType(SqlDbType.TinyInt.ToString()).IsRequired();
            Property(m => m.IsRead).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(m => m.IsReplied).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();

            HasMany(u => u.MessageResponses).WithMany(c => c.Messages).Map(m =>
            {
                m.MapLeftKey("MessageId");
                m.MapRightKey("ResponseId");
                m.ToTable("Message_Response", SchemaConstant.Notification);
            });
        }
    }

    internal class MessageResponseConfiguration : EntityBaseConfiguration<MessageResponse>
    {
        public MessageResponseConfiguration()
        {
            ToTable("MessageResponse", SchemaConstant.Notification);
            Property(m => m.Body).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(500).IsRequired();

            HasMany(p => p.MessageResponses)
              .WithOptional()
              .HasForeignKey(pc => pc.ParentId)
              .WillCascadeOnDelete(false);
        }
    }

    internal class NewsletterConfiguration : EntityBaseConfiguration<Newsletter>
    {
        public NewsletterConfiguration()
        {
            ToTable("Newsletter", SchemaConstant.Notification);
            Property(n => n.Email).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired().HasMaxLength(80);
        }
    }
}