using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayCard.Infrastructure.Database.Models;

namespace PayCard.Infrastructure.Database.Configurations
{
    internal class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.ToTable("transaction_types", "banking");

            builder.HasKey(tt => tt.Id);

            builder.Property(tt => tt.Type)
                .HasColumnName("type")
                .HasColumnType("Varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(tt => tt.Type)
                .IsUnique()
                .HasDatabaseName("UQ_transaction_types_type");
        }
    }
}
