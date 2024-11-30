using PayCard.Domain.Banking.Exceptions;
using PayCard.Domain.Common.Models;
using PayCard.Domain.Common.Resources;

using static PayCard.Domain.Common.Constants.Currency;

namespace PayCard.Domain.Banking.Models.Account
{
    public class Currency : Entity<long>
    {
        internal Currency(string iso4217Code, string name, char symbol)
        {
            Guard.ForStringLength<InvalidCurrencyException>(iso4217Code, MinIsoCodeLength, MaxIsoCodeLength, nameof(Iso4217Code));
            Guard.ForStringLength<InvalidCurrencyException>(name, MinNameLength, MaxNameLength, nameof(Name));
            ValidateSymbol(symbol);

            Iso4217Code = iso4217Code;
            Name = name;
            Symbol = symbol;
        }

        public string Iso4217Code { get; private set; }

        public string Name { get; init; }

        public char Symbol { get; init; }

        private void ValidateSymbol(char symbol)
        {
            if (char.IsWhiteSpace(symbol))
            {
                throw new InvalidCurrencyException(string.Format(Global.FieldIsRequired, nameof(Symbol)));
            }
        }
    }
}
