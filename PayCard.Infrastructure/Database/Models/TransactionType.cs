namespace PayCard.Infrastructure.Database.Models
{
    public class TransactionType
    {
        public int Id { get; set; }

        public string Type { get; set; } = default!;

        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
