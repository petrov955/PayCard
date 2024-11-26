using MediatR;
using PayCard.Application.Account.Accounts.Queries.Contracts;

namespace PayCard.Application.Account.Accounts.Queries.Currency
{
    public class GetCurrenciesQuery : IRequest<IEnumerable<GetCurrencyOutputModel>>
    {
        public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, IEnumerable<GetCurrencyOutputModel>>
        {
            private readonly ICurrencyQueryRepository _currencyQueryRepository;

            public GetCurrenciesQueryHandler(ICurrencyQueryRepository currencyQueryRepository)
                => _currencyQueryRepository = currencyQueryRepository;

            public async Task<IEnumerable<GetCurrencyOutputModel>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
            {
                return await _currencyQueryRepository.GetCurrenciesAsync();
            }
        }
    }
}

