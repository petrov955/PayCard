namespace PayCard.Infrastructure.Database.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int TransactionTypeId { get; set; }

        public TransactionType TransactionType { get; set; } = default!;

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public int CurrencyId { get; set; }

        public Currency Currency { get; set; } = default!;

        public int SourceAccountId { get; set; }

        public Account SourceAccount { get; set; } = default!;

        public int DestinationAccountId { get; set; }

        public Account DestinationAccount { get; set; } = default!;

        public int TransactionStatusId { get; set; }

        public TransactionStatus Status { get; set; } = default!;

        public string? Note { get; set; }

        public decimal ExchangeRate { get; set; }

        public decimal Fee { get; set; }
    }
}
