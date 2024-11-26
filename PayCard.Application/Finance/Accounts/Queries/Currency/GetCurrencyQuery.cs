using MediatR;
using PayCard.Application.Common;
using PayCard.Application.Account.Accounts.Queries.Contracts;

namespace PayCard.Application.Account.Accounts.Queries.Currency
{
    public class GetCurrencyQuery : EntityCommand<long>, IRequest<GetCurrencyOutputModel>
    {
        public class GetCurrencyQueryHandler : IRequestHandler<GetCurrencyQuery, GetCurrencyOutputModel>
        {
            private readonly ICurrencyQueryRepository _currencyQueryRepository;
            public GetCurrencyQueryHandler(ICurrencyQueryRepository currencyQueryRepository)
                => _currencyQueryRepository = currencyQueryRepository;

            public async Task<GetCurrencyOutputModel> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
            {
                return await _currencyQueryRepository.GetCurrencyAsync(request.Id);
            }
        }
    }
}
