using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayCard.Infrastructure.Database.Models;

namespace PayCard.Infrastructure.Database.Configurations
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("countries", "users");

            builder.HasKey(country => country.Id);

            builder.Property(country => country.ISO3166Code)
                .HasColumnName("iso_3166_code")
                .HasColumnType("Varchar")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(country => country.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsRequired();

            builder.HasIndex(country => new { country.ISO3166Code, country.Name })
                .IsUnique()
                .HasDatabaseName("UQ_countries_iso_3166_code_name");
        }
    }
}
