using PayCard.Domain.Common.Models;
using PayCard.Domain.Finance.Exceptions;
using PayCard.Domain.Finance.Models.Account;

using static PayCard.Domain.Common.Constants.Country;

namespace PayCard.Domain.Finance.Models
{
    public class Country : Entity<long>
    {
        internal Country(string name, string iso3166Code, Currency currency)
        {
            Guard.AgainstEmptyString<InvalidCountryException>(name, nameof(Name));
            Guard.ForStringLength<InvalidCountryException>(iso3166Code, MinIsoCodeLength, MaxIsoCodeLength, nameof(ISO3166Code));

            Name = name;
            ISO3166Code = iso3166Code;
            Currency = currency;
        }

        public string Name { get; private set; }

        public string ISO3166Code { get; private set; }

        public Currency Currency { get; init; }

        public void UpdateName(string name)
        {
            Guard.AgainstEmptyString<InvalidCountryException>(name, nameof(Name));
            Name = name;
        }

        public void UpdateIsoCode(string iso3166Code)
        {
            Guard.ForStringLength<InvalidCountryException>(iso3166Code, MinIsoCodeLength, MaxIsoCodeLength, nameof(ISO3166Code));
            ISO3166Code = iso3166Code;
        }
    }
}
