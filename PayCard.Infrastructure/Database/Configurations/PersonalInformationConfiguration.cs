using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayCard.Infrastructure.Database.Models;

namespace PayCard.Infrastructure.Database.Configurations
{
    internal class PersonalInformationConfiguration : IEntityTypeConfiguration<PersonalInformation>
    {
        public void Configure(EntityTypeBuilder<PersonalInformation> builder)
        {
            builder.ToTable("personal_information", "users");

            builder.HasKey(pi => pi.Id);

            builder.Property(pi => pi.FullName)
                .HasColumnName("full_name")
                .HasColumnType("Nvarchar")
                .HasMaxLength(81)
                .IsRequired();

            builder.Property(pi => pi.GenderId)
                .HasColumnType("int")
                .HasColumnName("gender_id")
                .IsRequired();

            builder.Property(pi => pi.DOB)
                .HasColumnName("date_of_birth")
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(pi => pi.AddressId)
               .HasColumnType("int")
               .HasColumnName("address_id")
               .IsRequired();

            builder.Property(pi => pi.EmailAddress)
               .HasColumnName("email_address")
               .HasColumnType("Varchar")
               .HasMaxLength(320)
               .IsRequired();

            builder.Property(pi => pi.PhoneNumber)
               .HasColumnName("phone_number")
               .HasColumnType("Varchar")
               .HasMaxLength(17)
               .IsRequired();

            builder.HasOne(pi => pi.Address)
                .WithMany(address => address.PersonalInformation)
                .HasForeignKey(pi => pi.AddressId)
                .HasConstraintName("FK_personal_information_addresses_address_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pi => pi.Gender)
                .WithMany(gender => gender.PersonalInformation)
                .HasForeignKey(pi => pi.GenderId)
                .HasConstraintName("FK_personal_information_genders_gender_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pi => new { pi.EmailAddress, pi.PhoneNumber })
                .IsUnique()
                .HasDatabaseName("UQ_personal_information_email_address_phone_number");
        }
    }
}
