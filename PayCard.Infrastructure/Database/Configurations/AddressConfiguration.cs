using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayCard.Infrastructure.Database.Models;

namespace PayCard.Infrastructure.Database.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("addresses", "users");

            builder.HasKey(address => address.Id);

            builder.Property(address => address.CountryId)
                .HasColumnName("country_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(address => address.City)
                .HasColumnName("city")
                .HasColumnType("Nvarchar")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(address => address.AddressLine1)
                .HasColumnName("address_line_1")
                .HasColumnType("Nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(address => address.AddressLine2)
               .HasColumnName("address_line_2")
               .HasColumnType("Nvarchar")
               .HasMaxLength(100)
               .IsRequired(false);

            builder.Property(address => address.District)
              .HasColumnName("district")
              .HasColumnType("Nvarchar")
              .HasMaxLength(45)
              .IsRequired(false);

            builder.Property(address => address.PostalCode)
              .HasColumnName("postal_code")
              .HasColumnType("Nvarchar")
              .HasMaxLength(10)
              .IsRequired(false);

            builder
                .HasOne(address => address.Country)
                .WithMany(country => country.Addresses)
                .HasForeignKey(address => address.CountryId)
                .HasConstraintName("FK_adresses_countries_country_id")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
