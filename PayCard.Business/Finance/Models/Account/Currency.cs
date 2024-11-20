using PayCard.Domain.Common;
using PayCard.Domain.Finance.Exceptions;

using static PayCard.Domain.Common.Constants.Currency;

namespace PayCard.Domain.Finance.Models.Account
{
    public class Currency : Entity<long>
    {
        internal Currency(string isoCode)
        {
            Guard.ForStringLength<InvalidCurrencyException>(isoCode, MinIsoCodeLength, MaxIsoCodeLength, nameof(IsoCode));

            IsoCode = isoCode;
        }

        public string IsoCode { get; private set; }
    }
}
