using PayCard.Domain.Common;
using PayCard.Domain.Exceptions;
using System.Text.RegularExpressions;

using static PayCard.Domain.Common.Constants.Address;
using static PayCard.Domain.Common.Constants.Numeric;

namespace PayCard.Domain.Models
{
    public class Address
    {
        internal Address(Country country, string city, string addressLine1, string addressLine2, string district, string postalCode)
        {
            Validate(city, addressLine1, addressLine2, district, postalCode);

            Country = country;
            City = city;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            District = district;
            PostalCode = postalCode;
        }

        public Country Country { get; private set; }
        public string City { get; private set; }
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string District { get; private set; }
        public string PostalCode { get; private set; }

        public void UpdateCountry(Country country)
        {
            Country = country;
        }

        public void UpdateCity(string city)
        {
            Guard.ForStringLength<InvalidMemberException>(city, MinCityLength, MaxCityLength, nameof(City));
            City = city;
        }

        public void UpdateAddressLine1(string addressLine1)
        {
            Guard.ForStringLength<InvalidMemberException>(addressLine1, Zero, MaxAddressLength, nameof(AddressLine1));
            AddressLine1 = addressLine1;
        }

        public void UpdateAddressLine2(string addressLine2)
        {
            Guard.ForStringLength<InvalidMemberException>(addressLine2, Zero, MaxAddressLength, nameof(AddressLine2));
            AddressLine2 = addressLine2;
        }


        public void UpdateDistrict(string district)
        {
            Guard.ForStringLength<InvalidMemberException>(district, Zero, MaxDistrictLength, nameof(District));
            District = district;
        }

        public void UpdatePostalCode(string postalCode)
        {
            ValidatePostalCode(postalCode);
            PostalCode = postalCode;
        }

        private void ValidatePostalCode(string postalCode)
        {
            var regex = new Regex(Constants.RegexPattern.PostalCode);
            if (!regex.IsMatch(postalCode))
            {
                throw new InvalidMemberException("Invalid Postal code.");
            }
        }

        private void Validate(string city, string addressLine1, string addressLine2, string district, string postalCode)
        {
            Guard.ForStringLength<InvalidMemberException>(city, MinCityLength, MaxCityLength, nameof(City));
            Guard.ForStringLength<InvalidMemberException>(addressLine1, Zero, MaxAddressLength, nameof(AddressLine1));
            Guard.ForStringLength<InvalidMemberException>(addressLine2, Zero, MaxAddressLength, nameof(AddressLine2));
            Guard.ForStringLength<InvalidMemberException>(district, Zero, MaxDistrictLength, nameof(District));
            ValidatePostalCode(postalCode);
        }
    }
}
