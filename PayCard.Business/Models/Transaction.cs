using PayCard.Domain.Common;
using PayCard.Domain.Enums;

namespace PayCard.Domain.Models
{
    public class Transaction : Entity<Guid>
    {
        internal Transaction()
        {

        }

        public Guid Id { get; private set; }

        public TransactionType TransactionType { get; private set; }

        public decimal Amount { get; private set; }

        public DateTime Date { get; private set; }

        public Currency Currency { get; private set; }

        public Account SourceAccount { get; private set; }

        public Account DestinationAccount { get; private set; }

        public TransactionStatus Status { get; private set; }

        public string Note { get; private set; }

        public decimal ExchangeRate { get; private set; }

        public decimal Fee { get; private set; }
    }
}
