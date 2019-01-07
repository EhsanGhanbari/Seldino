using System.Data;
using System.Data.Entity.ModelConfiguration;
using Seldino.Infrastructure.Domain;

namespace Seldino.Repository.Infrastructure
{
    internal abstract class ValueObjectBaseConfiguration<TValueObject> : EntityTypeConfiguration<TValueObject> where TValueObject : ValueObjectBase
    {
        protected ValueObjectBaseConfiguration()
        {
            Property(p => p.CreationDate).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
            Property(p => p.Creator).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired();
        }
    }
}
