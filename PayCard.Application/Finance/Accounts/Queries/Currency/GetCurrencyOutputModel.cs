namespace PayCard.Application.Account.Accounts.Queries.Currency
{
    public class GetCurrencyOutputModel
    {
        public long Id { get; }
        
        public string IsoCode { get; private set; }

        public string Name { get; private set; }

        public char Symbol { get; private set; }
    }
}
