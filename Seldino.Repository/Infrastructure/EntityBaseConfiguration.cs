using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity.ModelConfiguration;
using Seldino.Infrastructure.Domain;

namespace Seldino.Repository.Infrastructure
{
    internal abstract class EntityBaseConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        protected EntityBaseConfiguration()
        {
            HasKey(e => e.Id).Property(e => e.Id).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
            Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.CreationDate).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
            Property(e => e.LastUpdateDate).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
            Property(e => e.IsDeleted).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
        }
    }
}
