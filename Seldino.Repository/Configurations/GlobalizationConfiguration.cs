using Seldino.Domain.GlobalizationAggregation;
using Seldino.Repository.Infrastructure;
using System.Data;

namespace Seldino.Repository.Configurations
{
    internal class LanguageConfiguration : EntityBaseConfiguration<Language>
    {
        public LanguageConfiguration()
        {
            ToTable("Language", SchemaConstant.Globalization);
            Property(e => e.CultureCode).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(50).IsRequired();
            Property(e => e.Name).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(50).IsRequired();
            Property(e => e.IsRightToLeft).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(e => e.IsDefault).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
            Property(e => e.IsActive).HasColumnType(SqlDbType.Bit.ToString()).IsRequired();
        }
    }
}
