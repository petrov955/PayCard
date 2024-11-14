﻿using PayCard.Domain.Common;
using PayCard.Domain.Exceptions;
using System.Text.RegularExpressions;

using static PayCard.Domain.Common.Constants.Address;
using static PayCard.Domain.Common.Constants.Numeric;

namespace PayCard.Domain.Finance.ValueObjects
{
    public class Address : ValueObject
    {
        internal Address(
            string country,
            string city,
            string addressLine1,
            string addressLine2,
            string district,
            string postalCode)
        {
            Validate(city, addressLine1, addressLine2, district, postalCode);

            Country = country;
            City = city;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            District = district;
            PostalCode = postalCode;
        }

        public string Country { get; }
        public string City { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string District { get; }
        public string PostalCode { get; }

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
