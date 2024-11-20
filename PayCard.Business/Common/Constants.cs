namespace PayCard.Domain.Common
{
    internal static class Constants
    {
        internal static class Currency
        {
            public const int MinIsoCodeLength = 3;

            public const int MaxIsoCodeLength = 3;
        }

        internal static class Country
        {
            public const int MinIsoCodeLength = 2;

            public const int MaxIsoCodeLength = 2;
        }

        internal static class User
        {
            public const int MaxUsernameLength = 40;

            public const int MinUsernameLength = 1;

            public const int MinPasswordBytesSize = 8;

            public const int MaxPasswordBytesSize = 255;
        }

        internal static class PI
        {
            public const int MinNameLength = 1;

            public const int MaxNameLength = 40;

            public const int MaxEmailLength = 80;
        }

        internal static class Account
        {
            public const int MinDescriptionLength = 3;

            public const int MaxDescriptionLength = 140;

            public const decimal MinBalance = 0m;

            public const decimal MaxBalance = Decimal.MaxValue;

            public const int MaxBeneficiaryLength = 90;

            public const int MinBeneficiaryLength = 2;

            public const int MaxBankNameLength = 60;

            public const int MinBankNameLength = 5;
        }

        internal static class Address
        {
            public const int MaxAddressLength = 100;

            public const int MinCityLength = 1;

            public const int MaxCityLength = 80;

            public const int MaxDistrictLength = 45;
        }

        internal static class Numeric
        {
            public const int Zero = 0;

            public const int One = 1;

            public const int Two = 2;

            public const int Three = 3;

            public const int Four = 4;

            public const int Five = 5;

            public const int Six = 6;
        }

        internal static class RegexPattern
        {
            public const string Email = @"^[\.\w-]+@([\w-]+\.)+[\w]{2,4}$";

            public const string PhoneNumber = @"^(\+\d{1,3}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";

            public const string PostalCode = @"^[A-Z\-]{0,3}[\s]?[0-9]{3,10}[\-]?[A-Z]?$";

            public const string IBAN = @"^[A-Z]{2}[0-9]{2}[A-Z0-9]{11,30}$";

            public const string Swift = @"^[A-Z0-9]{8,11}$";
        }
    }
}
