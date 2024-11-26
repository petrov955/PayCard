using PayCard.Domain.Common.Models;
using PayCard.Domain.Accounts.Exceptions;

using static PayCard.Domain.Common.Constants.Currency;

namespace PayCard.Domain.Accounts.Models.Account
{
    public class Currency : Entity<long>
    {
        internal Currency(string isoCode, string name, char symbol)
        {
            Guard.ForStringLength<InvalidCurrencyException>(isoCode, MinIsoCodeLength, MaxIsoCodeLength, nameof(IsoCode));
            Guard.AgainstEmptyString<InvalidCurrencyException>(name, nameof(Name));
            ValidateSymbol(symbol);
           
            IsoCode = isoCode;
            Name = name;
            Symbol = symbol;
        }

        public string IsoCode { get; private set; }

        public string Name { get; init; }

        public char Symbol { get; init; }

        private void ValidateSymbol(char symbol)
        {
            if (char.IsWhiteSpace(symbol))
            {
                throw new InvalidCurrencyException($"{nameof(Symbol)} is required.");
            }
        }
    }
}
