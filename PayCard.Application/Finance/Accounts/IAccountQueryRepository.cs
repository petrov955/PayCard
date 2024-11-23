using PayCard.Application.Finance.Accounts.Queries.Accounts;

namespace PayCard.Application.Finance.Accounts
{
    public interface IAccountQueryRepository
    {
        Task<GetAccountDetailsOutputModel> GetAccountDetailsAsync(long accountId, CancellationToken cancelationToken = default);
        
        Task<IEnumerable<GetAccountDetailsOutputModel>> GetAccountsDetailsAsync(
            long userId, 
            bool getActive = true , 
            CancellationToken cancelationToken = default);

    }
}