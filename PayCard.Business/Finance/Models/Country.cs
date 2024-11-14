using PayCard.Domain.Common;
using PayCard.Domain.Exceptions;

using static PayCard.Domain.Common.Constants.Country;

namespace PayCard.Domain.Finance.Models
{
    public class Country : Entity<long>
    {
        internal Country(string name, string iso3166Code, Currency currency)
        {
            Guard.AgainstEmptyString<InvalidMemberException>(name, nameof(Name));
            Guard.ForStringLength<InvalidMemberException>(iso3166Code, MinIsoCodeLength, MaxIsoCodeLength, nameof(ISO3166Code));

            Name = name;
            ISO3166Code = iso3166Code;
            Currency = currency;
        }

        public string Name { get; private set; }

        public string ISO3166Code { get; private set; }

        public Currency Currency { get; init; }

        public void UpdateName(string name)
        {
            Guard.AgainstEmptyString<InvalidMemberException>(name, nameof(Name));
            Name = name;
        }

        public void UpdateIsoCode(string iso3166Code)
        {
            Guard.ForStringLength<InvalidMemberException>(iso3166Code, MinIsoCodeLength, MaxIsoCodeLength, nameof(ISO3166Code));
            ISO3166Code = iso3166Code;
        }
    }
}
