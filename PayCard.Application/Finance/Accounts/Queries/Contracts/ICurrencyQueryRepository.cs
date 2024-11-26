using PayCard.Application.Account.Accounts.Queries.Currency;

namespace PayCard.Application.Account.Accounts.Queries.Contracts
{
    public interface ICurrencyQueryRepository
    {
        Task<IEnumerable<GetCurrencyOutputModel>> GetCurrenciesAsync(CancellationToken cancellationToken = default);

        Task<GetCurrencyOutputModel> GetCurrencyAsync(long currencyId, CancellationToken cancellationToken = default);
    }
}
