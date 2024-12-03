using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayCard.Infrastructure.Database.Models;

namespace PayCard.Infrastructure.Database.Configurations
{
    internal class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("genders", "users");

            builder.HasKey(gender => gender.Id);

            builder.Property(gender => gender.Type)
                .HasColumnType("Varchar")
                .HasColumnName("type")
                .HasMaxLength(6)
                .IsRequired();

            builder.HasIndex(gender => gender.Type)
                .IsUnique()
                .HasDatabaseName("UQ_genders_type");
        }
    }
}
