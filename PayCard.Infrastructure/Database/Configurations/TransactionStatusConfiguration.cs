using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayCard.Infrastructure.Database.Models;

namespace PayCard.Infrastructure.Database.Configurations
{
    internal class TransactionStatusConfiguration : IEntityTypeConfiguration<TransactionStatus>
    {
        public void Configure(EntityTypeBuilder<TransactionStatus> builder)
        {
            builder.ToTable("transaction_statuses", "banking");

            builder.HasKey(ts => ts.Id);

            builder.Property(ts => ts.Status)
                .HasColumnName("status")
                .HasColumnType("Varchar")
                .HasMaxLength(15)
                .IsRequired();

            builder.HasIndex(ts => ts.Status)
                .IsUnique()
                .HasDatabaseName("UQ_transaction_statuses_status");
        }
    }
}
