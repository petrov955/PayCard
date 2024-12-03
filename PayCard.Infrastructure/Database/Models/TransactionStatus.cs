namespace PayCard.Infrastructure.Database.Models
{
    public class TransactionStatus
    {
        public int Id { get; set; }

        public string Status { get; set; } = default!;

        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
