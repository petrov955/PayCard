using MediatR;
using PayCard.Application.Common;
using PayCard.Application.Account.Accounts.Queries.Contracts;

namespace PayCard.Application.Account.Accounts.Queries.Accounts
{
    public class GetAccountQuery : EntityCommand<long> , IRequest<GetAccountOutputModel>
    {
        public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, GetAccountOutputModel>
        {
            private readonly IAccountQueryRepository _accountRepository;

            public GetAccountQueryHandler(IAccountQueryRepository accountRepository)
                => _accountRepository = accountRepository;

            public async Task<GetAccountOutputModel> Handle(
                GetAccountQuery request,
                CancellationToken cancellationToken = default)
                => await _accountRepository.GetAccountDetailsAsync(request.Id, cancellationToken);
        }
    }
}
