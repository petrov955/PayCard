using MediatR;

namespace PayCard.Application.Finance.Accounts.Queries.Accounts
{
    public class GetAccountsDetailsQuery : IRequest<IEnumerable<GetAccountDetailsOutputModel>>
    {
        public GetAccountsDetailsQuery(long userId, bool getActive)
        {
            UserId = userId;
            GetActive = getActive;
        }

        public long UserId { get; }
       
        public bool GetActive { get; }
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
}
