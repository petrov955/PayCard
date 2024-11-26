using PayCard.Domain.Common.Contracts;
using PayCard.Domain.Common.Models;
using PayCard.Domain.Payments.Enums;
using PayCard.Domain.Payments.Exceptions;

using static PayCard.Domain.Common.Constants.Transaction;

namespace PayCard.Domain.Payments.Models
{
    public class Transaction : Entity<Guid>, IAggregateRoot
    {
        internal Transaction(
            TransactionType transactionType,
            decimal amount,
            Currency currency,
            Account sourceAccountId,
            Account destinationAccountId,
            TransactionStatus status,
            string? note,
            decimal exchangeRate = DefaultExchangeRate,
            decimal fee = DefaultFee)
        {
            Validate(amount, exchangeRate, fee);

            TransactionType = transactionType;
            Amount = amount;
            Date = DateTime.UtcNow;
            Currency = currency;
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
            Status = status;
            Note = note;
            ExchangeRate = exchangeRate;
            Fee = fee;
        }

        public TransactionType TransactionType { get; }

        public decimal Amount { get; }

        public DateTime Date { get; }

        public Currency Currency { get; }

        public Account SourceAccountId { get; }

        public Account DestinationAccountId { get; }

        public TransactionStatus Status { get; }

        public string? Note { get; }

        public decimal ExchangeRate { get; }

        public decimal Fee { get; }

        private static void Validate(decimal amount, decimal exchangeRate, decimal fee)
        {
            Guard.AgainstNegativeNumber<InvalidTransactionException>(amount);
            Guard.AgainstNegativeNumber<InvalidTransactionException>(exchangeRate);
            Guard.AgainstNegativeNumber<InvalidTransactionException>(fee);
        }
    }
}
