using PayCard.Domain.Common;
using PayCard.Domain.Exceptions;

using static PayCard.Domain.Common.Constants.Currency;

namespace PayCard.Domain.Models
{
    public class Currency
    {
        internal Currency(string isoCode)
        {
            Guard.ForStringLength<InvalidMemberException>(isoCode, MinIsoCodeLength, MaxIsoCodeLength, nameof(this.IsoCode));
            this.IsoCode = isoCode;
        }

        public string IsoCode { get; private set; }

        public void UpdateIsoCode(string isoCode)
        {
            Guard.ForStringLength<InvalidMemberException>(isoCode, MinIsoCodeLength, MaxIsoCodeLength, nameof(this.IsoCode));
            this.IsoCode = isoCode;
        }
    }
}
