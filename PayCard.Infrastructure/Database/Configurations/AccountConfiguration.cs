using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayCard.Infrastructure.Database.Models;

namespace PayCard.Infrastructure.Database.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts", "banking");

            builder.HasKey(account => account.Id);

            builder.Property(account => account.PersonalInformationId)
                .HasColumnName("personal_information_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(account => account.BankName)
                .HasColumnName("bank_name")
                .HasColumnType("Nvarchar")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(account => account.IBAN)
                .HasColumnName("iban")
                .HasColumnType("Varchar")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(account => account.SwiftOrBIC)
                .HasColumnName("swift_or_bic")
                .HasColumnType("Varchar")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(account => account.AccountDescription)
               .HasColumnName("description")
               .HasColumnType("Nvarchar")
               .HasMaxLength(140)
               .IsRequired(false);

            builder.Property(account => account.Balance)
              .HasColumnName("balance")
              .HasColumnType("Decimal(18,2)")
              .IsRequired();

            builder.Property(account => account.CurrencyId)
                .HasColumnName("currency_id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(account => account.MonthlyTransactionsLimit)
                .HasColumnName("monthly_transaction_limit")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(account => account.WeeklyTransactionsLimit)
                .HasColumnName("weekly_transaction_limit")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(account => account.DailyTransactionsLimit)
                .HasColumnName("daily_transaction_limit")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(account => account.IsActive)
                .HasColumnType("Bit")
                .HasColumnName("is_active")
                .IsRequired();

            builder.HasOne(account => account.Currency)
                .WithMany(currency => currency.Accounts)
                .HasForeignKey(account => account.CurrencyId)
                .HasConstraintName("FK_accounts_currencies_currency_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(account => account.PersonalInformation)
                .WithMany(pi => pi.Accounts)
                .HasForeignKey(account => account.PersonalInformationId)
                .HasConstraintName("FK_accounts_personal_information_personal_information_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(account => account.IBAN)
                .IsUnique()
                .HasDatabaseName("UQ_accounts_iban");
        }
    }
}
