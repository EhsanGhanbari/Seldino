using System.Data;
using Seldino.Domain.PaymentAggregation;
using Seldino.Repository.Infrastructure;

namespace Seldino.Repository.Configurations
{
    internal class PaymentConfiguration : EntityBaseConfiguration<Payment>
    {
        public PaymentConfiguration()
        {
            ToTable("Payment", SchemaConstant.Payment);

            Property(s => s.Status).HasColumnType(SqlDbType.TinyInt.ToString()).IsRequired();
            Property(s => s.Amount).HasColumnType(SqlDbType.Decimal.ToString()).IsRequired();
            Property(s => s.Merchant).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired();
            Property(s => s.TransactionId).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired();
            Property(s => s.PaymentDate).HasColumnType(SqlDbType.DateTime.ToString()).IsRequired();
        }
    }

    internal class InvoiceConfiguration : EntityBaseConfiguration<Invoice>
    {
        public InvoiceConfiguration()
        {
            ToTable("Invoice", SchemaConstant.Payment);

            Property(d => d.UserId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
            HasRequired(d => d.User).WithMany().HasForeignKey(p => p.UserId).WillCascadeOnDelete(false);

            Property(d => d.PaymentId).HasColumnType(SqlDbType.UniqueIdentifier.ToString()).IsRequired();
            HasRequired(d => d.Payment).WithMany().HasForeignKey(p => p.PaymentId).WillCascadeOnDelete(false);

            Property(p => p.Amount).HasColumnType(SqlDbType.Decimal.ToString()).HasPrecision(18, 2).IsRequired();
            Property(p => p.Code).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired();
        }
    }
}
