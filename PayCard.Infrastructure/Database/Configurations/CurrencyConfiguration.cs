using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayCard.Infrastructure.Database.Models;

namespace PayCard.Infrastructure.Database.Configurations
{
    internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("currencies", "banking");

            builder.HasKey(currency => currency.Id);

            builder.Property(currency => currency.Name)
                .HasColumnName("name")
                .HasColumnType("Varchar")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(currency => currency.Iso4217Code)
                .HasColumnName("iso_4217_code")
                .HasColumnType("Varchar")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(currency => currency.Symbol)
                .HasColumnName("symbol")
                .HasColumnType("Char")
                .HasMaxLength(3)
                .IsRequired();

            builder.HasIndex(currency => new { currency.Iso4217Code, currency.Name })
                .IsUnique()
                .HasDatabaseName("UQ_currencies_iso_4217_code_name");
        }
    }
}
