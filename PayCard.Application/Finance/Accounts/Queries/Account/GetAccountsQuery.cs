using MediatR;
using PayCard.Application.Account.Accounts.Queries.Contracts;

namespace PayCard.Application.Account.Accounts.Queries.Accounts
{
    public class GetAccountsQuery : IRequest<IEnumerable<GetAccountOutputModel>>
    {
        public GetAccountsQuery(long userId, bool getActive)
        {
            UserId = userId;
            GetActive = getActive;
        }

        public long UserId { get; }
       
        public bool GetActive { get; }


        public class GetAccountsDetailsQueryHandler : IRequestHandler<GetAccountsQuery, IEnumerable<GetAccountOutputModel>>
        {
            private readonly IAccountQueryRepository _accountQueryRepository;

            public GetAccountsDetailsQueryHandler(IAccountQueryRepository accountQueryRepository)
                => _accountQueryRepository = accountQueryRepository;

            public async Task<IEnumerable<GetAccountOutputModel>> Handle(
                GetAccountsQuery request,
                CancellationToken cancellationToken = default)
                => await _accountQueryRepository.GetAccountsDetailsAsync(request.UserId, request.GetActive);
        }
    }
}
