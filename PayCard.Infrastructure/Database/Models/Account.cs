namespace PayCard.Infrastructure.Database.Models
{
    public class Account
    {
        public int Id { get; set; }

        public int PersonalInformationId { get; set; }

        public PersonalInformation PersonalInformation { get; set; } = default!;

        public string AccountDescription { get; set; } = default!;

        public decimal Balance { get; set; }

        public int CurrencyId { get; set; }

        public Currency Currency { get; set; } = default!;

        public string IBAN { get; set; } = default!;

        public string SwiftOrBIC { get; set; } = default!;

        public string BankName { get; set; } = default!;

        public int DailyTransactionsLimit { get; set; }

        public int WeeklyTransactionsLimit { get; set; }

        public int MonthlyTransactionsLimit { get; set; }

        public bool IsActive { get; private set; }

        public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
    }
}
