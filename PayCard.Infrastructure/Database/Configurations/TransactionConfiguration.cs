using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayCard.Infrastructure.Database.Models;

namespace PayCard.Infrastructure.Database.Configurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions", "banking");

            builder.HasKey(transaction => transaction.Id);

            builder.Property(transaction => transaction.TransactionTypeId)
                .HasColumnName("transaction_type_id")
                .HasColumnType("Int")
                .IsRequired();

            builder.Property(transaction => transaction.TransactionStatusId)
                .HasColumnName("transaction_status_id")
                .HasColumnType("Int")
                .IsRequired();

            builder.Property(transaction => transaction.Date)
                .HasColumnName("date")
                .HasColumnType("smalldatetime")
                .IsRequired();

            builder.Property(transaction => transaction.Amount)
                .HasColumnName("amount")
                .HasColumnType("Decimal(18,2)")
                .IsRequired();

            builder.Property(transaction => transaction.CurrencyId)
               .HasColumnName("currency_id")
               .HasColumnType("Int")
               .IsRequired();

            builder.Property(transaction => transaction.ExchangeRate)
                .HasColumnName("exchange_rate")
                .HasColumnType("Decimal(18,2)")
                .IsRequired();

            builder.Property(transaction => transaction.Fee)
                .HasColumnName("fee")
                .HasColumnType("Decimal(18,2)")
                .IsRequired();

            builder.Property(transaction => transaction.SourceAccountId)
                .HasColumnName("source_account_id")
                .HasColumnType("Int")
                .IsRequired();

            builder.Property(transaction => transaction.DestinationAccountId)
               .HasColumnName("destination_account_id")
               .HasColumnType("Int")
               .IsRequired();

            builder.Property(transaction => transaction.Note)
              .HasColumnName("note")
              .HasColumnType("Nvarchar")
              .HasMaxLength(256)
              .IsRequired(false);

            builder.HasOne(transaction => transaction.Currency)
                .WithMany(currency => currency.Transactions)
                .HasForeignKey(transaction => transaction.CurrencyId)
                .HasConstraintName("FK_transactions_currencies_currency_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(transaction => transaction.Status)
                .WithMany(status => status.Transactions)
                .HasForeignKey(transaction => transaction.TransactionStatusId)
                .HasConstraintName("FK_transactions_transaction_statuses_transaction_status_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(transaction => transaction.TransactionType)
               .WithMany(type => type.Transactions)
               .HasForeignKey(transaction => transaction.TransactionTypeId)
               .HasConstraintName("FK_transactions_transaction_types_transaction_type_id")
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(transaction => transaction.SourceAccount)
              .WithMany(account => account.Transactions)
              .HasForeignKey(transaction => transaction.SourceAccountId)
              .HasConstraintName("FK_transactions_accounts_account_id")
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
