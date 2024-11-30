using PayCard.Domain.Common.Models;
using PayCard.Domain.Users.Exceptions;

using static PayCard.Domain.Common.Constants.Country;

namespace PayCard.Domain.Users.Models
{
    public class Country : Entity<long>
    {
        internal Country(string name, string iso3166Code)
        {
            Guard.AgainstEmptyString<InvalidCountryException>(name, nameof(Name));
            Guard.ForStringLength<InvalidCountryException>(iso3166Code, MinIsoCodeLength, MaxIsoCodeLength, nameof(ISO3166Code));

            Name = name;
            ISO3166Code = iso3166Code;
        }

        public string Name { get; private set; }

        public string ISO3166Code { get; private set; }

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
