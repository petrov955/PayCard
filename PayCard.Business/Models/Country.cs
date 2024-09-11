using PayCard.Domain.Common;
using PayCard.Domain.Exceptions;

using static PayCard.Domain.Common.Constants.Country;

namespace PayCard.Domain.Models
{
    public class Country
    {
        public Country(string name, string iso3166Code, Currency currency)
        {
            Guard.AgainstEmptyString<InvalidMemberException>(name, nameof(this.Name));
            Guard.ForStringLength<InvalidMemberException>(iso3166Code, MinIsoCodeLength, MaxIsoCodeLength, nameof(this.ISO3166Code));

            this.Name = name;
            this.ISO3166Code = iso3166Code;
            this.Currency = currency;
        }

        public string Name { get; private set; }

        public string ISO3166Code { get; private set; }

        public Currency Currency { get; private set; }

        public void UpdateName(string name)
        {
            Guard.AgainstEmptyString<InvalidMemberException>(name, nameof(this.Name));
            this.Name = name;
        }

        public void UpdateIsoCode(string iso3166Code)
        {
            Guard.ForStringLength<InvalidMemberException>(iso3166Code, MinIsoCodeLength, MaxIsoCodeLength, nameof(this.ISO3166Code));
        }
    }
}
