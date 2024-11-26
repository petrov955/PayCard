using MediatR;
using PayCard.Application.Finance.Accounts.Queries.Accounts;

namespace PayCard.Application.Finance.Accounts.Handlers.Account
{
    public class GetAccountsDetailsQueryHandler : IRequestHandler<GetAccountsDetailsQuery, IEnumerable<GetAccountDetailsOutputModel>>
    {
        private readonly IAccountQueryRepository _accountQueryRepository;

        public GetAccountsDetailsQueryHandler(IAccountQueryRepository accountQueryRepository)
            => _accountQueryRepository = accountQueryRepository;

        public async Task<IEnumerable<GetAccountDetailsOutputModel>> Handle(
            GetAccountsDetailsQuery request,
            CancellationToken cancellationToken = default)
            => await _accountQueryRepository.GetAccountsDetailsAsync(request.UserId, request.GetActive);
    }
}
