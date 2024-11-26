using PayCard.Domain.Common.Models;
using PayCard.Domain.Accounts.Exceptions;

using static PayCard.Domain.Common.Constants.Currency;

namespace PayCard.Domain.Payments.Models
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
