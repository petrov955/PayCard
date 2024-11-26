using MediatR;
using PayCard.Application.Common;

namespace PayCard.Application.Finance.Accounts.Queries.Accounts
{
    public class GetAccountDetailsQuery : EntityCommand<long> , IRequest<GetAccountDetailsOutputModel>
    {
        public class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery,GetAccountDetailsOutputModel>
        {
            private readonly IAccountQueryRepository _accountRepository;

            public GetAccountDetailsQueryHandler(IAccountQueryRepository accountRepository)
                => _accountRepository = accountRepository;

            public async Task<GetAccountDetailsOutputModel> Handle(
                GetAccountDetailsQuery request, 
                CancellationToken cancellationToken = default)
                => await _accountRepository.GetAccountDetailsAsync(request.Id, cancellationToken);
        }
    }
}
