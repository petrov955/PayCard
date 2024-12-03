namespace PayCard.Infrastructure.Database.Models
{
    public class Currency
    {
        public int Id { get; set; }
        
        public string Iso4217Code { get; set; } = default!;

        public string Name { get; set; } = default!;

        public char Symbol { get; set; }

        public ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
        
        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
