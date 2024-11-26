namespace PayCard.Domain.Common
{
    internal static class Constants
    {
        internal static class Currency
        {
            public const byte MinIsoCodeLength = 3;

            public const byte MaxIsoCodeLength = 3;
        }

        internal static class Country
        {
            public const byte MinIsoCodeLength = 2;

            public const byte MaxIsoCodeLength = 2;
        }

        internal static class User
        {
            public const byte MaxUsernameLength = 40;

            public const byte MinUsernameLength = 1;

            public const byte MinPasswordBytesSize = 8;

            public const byte MaxPasswordBytesSize = 255;
        }

        internal static class PI
        {
            public const byte MinNameLength = 1;

            public const byte MaxNameLength = 40;

            public const byte MaxEmailLength = 80;
        }

        internal static class Account
        {
            public const byte MinDescriptionLength = 3;

            public const byte MaxDescriptionLength = 140;

            public const decimal MinBalance = 0m;

            public const decimal MaxBalance = Decimal.MaxValue;

            public const byte MaxBeneficiaryLength = 90;

            public const byte MinBeneficiaryLength = 2;

            public const byte MaxBankNameLength = 60;

            public const byte MinBankNameLength = 5;

            public const byte DailyTransactionsLimit = 20;

            public const byte WeeklyTransactionsLimit = 140;
            
            public const ushort MonthlyTransactionsLimit = 600;
        }

        internal static class Address
        {
            public const byte MaxAddressLength = 100;

            public const byte MinCityLength = 1;

            public const byte MaxCityLength = 80;

            public const byte MaxDistrictLength = 45;
        }

        internal static class Transaction
        {
            public const decimal DefaultFee = 0m;
            
            public const decimal DefaultExchangeRate = 1m;
        }

        internal static class Numeric
        {
            public const byte Zero = 0;

            public const byte One = 1;

            public const byte Two = 2;

            public const byte Three = 3;

            public const byte Four = 4;

            public const byte Five = 5;

            public const byte Six = 6;
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
