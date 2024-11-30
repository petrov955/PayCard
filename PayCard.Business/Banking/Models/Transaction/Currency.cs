using PayCard.Domain.Common.Models;

using static PayCard.Domain.Common.Constants.Currency;
using PayCard.Domain.Banking.Exceptions;

namespace PayCard.Domain.Banking.Models.Transaction
{
    public class Currency : Entity<long>
    {
        internal Currency(string iso4217Code)
        {
            Guard.ForStringLength<InvalidCurrencyException>(iso4217Code, MinIsoCodeLength, MaxIsoCodeLength, nameof(Iso4217Code));

            Iso4217Code = iso4217Code;
        }

        public string Iso4217Code { get; private set; }
    }
}
