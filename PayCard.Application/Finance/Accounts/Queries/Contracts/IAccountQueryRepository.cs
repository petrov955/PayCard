using PayCard.Application.Account.Accounts.Queries.Accounts;

namespace PayCard.Application.Account.Accounts.Queries.Contracts
{
    public interface IAccountQueryRepository
    {
        Task<GetAccountOutputModel> GetAccountDetailsAsync(long accountId, CancellationToken cancelationToken = default);

        Task<IEnumerable<GetAccountOutputModel>> GetAccountsDetailsAsync(
            long userId,
            bool getActive = true,
            CancellationToken cancelationToken = default);

    }
}