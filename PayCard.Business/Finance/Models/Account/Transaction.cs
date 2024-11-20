using PayCard.Domain.Common;
using PayCard.Domain.Finance.Enums;
using PayCard.Domain.Finance.Exceptions;

namespace PayCard.Domain.Finance.Models.Account
{
    public class Transaction : Entity<Guid>
    {
        internal Transaction(
            TransactionType transactionType,
            decimal amount,
            DateTime date,
            Currency currency,
            long sourceAccountId,
            long destinationAccountId,
            TransactionStatus status,
            string? note,
            decimal exchangeRate,
            decimal fee)
        {
            Validate(amount, sourceAccountId, destinationAccountId, exchangeRate, fee);

            TransactionType = transactionType;
            Amount = amount;
            Date = date;
            Currency = currency;
            SourceAccountId = sourceAccountId;
            DestinationAccountId = destinationAccountId;
            Status = status;
            Note = note;
            ExchangeRate = exchangeRate;
            Fee = fee;
        }

        public TransactionType TransactionType { get; init; }

        public decimal Amount { get; init; }

        public DateTime Date { get; init; }

        public Currency Currency { get; init; }

        public long SourceAccountId { get; init; }

        public long DestinationAccountId { get; init; }

        public TransactionStatus Status { get; init; }

        public string? Note { get; init; }

        public decimal ExchangeRate { get; init; }

        public decimal Fee { get; init; }

        private static void Validate(decimal amount, long sourceAccountId, long destinationAccountId, decimal exchangeRate, decimal fee)
        {
            Guard.AgainstNegativeNumber<InvalidTransactionException>(amount);
            Guard.AgainstNegativeNumber<InvalidTransactionException>(exchangeRate);
            Guard.AgainstNegativeNumber<InvalidTransactionException>(fee);
            Guard.AgainstNegativeNumber<InvalidTransactionException>(destinationAccountId);
            Guard.AgainstNegativeNumber<InvalidTransactionException>(sourceAccountId);
        }
    }
}
