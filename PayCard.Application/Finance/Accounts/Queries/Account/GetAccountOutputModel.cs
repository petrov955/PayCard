namespace PayCard.Application.Account.Accounts.Queries.Accounts
{
    public class GetAccountOutputModel
    {
        public long Id { get; private set; }
        
        public string AccountDescription { get; private set; }

        public decimal Balance { get; private set; }

        public string Currency { get; private set; }

        public string IBAN { get; private set; }

        public string BankName { get; private set; }

        public string Beneficiary { get; private set; }

        public bool IsActive { get; private set; }
    }
}
