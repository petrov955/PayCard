using PayCard.Domain.Common;
using PayCard.Domain.Exceptions;

using static PayCard.Domain.Common.Constants.Currency;

namespace PayCard.Domain.Finance.Models
{
    public class Currency : Entity<long>
    {
        internal Currency(string isoCode)
        {
            Guard.ForStringLength<InvalidMemberException>(isoCode, MinIsoCodeLength, MaxIsoCodeLength, nameof(IsoCode));

            IsoCode = isoCode;
        }

        public string IsoCode { get; private set; }
    }
}
