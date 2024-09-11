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

        internal static class Account
        {
            public const int MinDescriptionLength = 3;

            public const int MaxDescriptionLength = 140;

            public const decimal MinBalance = 0m;

            public const decimal MaxBalance = 1000000m;
        }

        internal static class Numeric
        {
            public const int One = 1;
           
            public const int Two = 2;
            
            public const int Three = 3;
            
            public const int Four = 4;
            
            public const int Five = 5;
            
            public const int Six = 6;
        }
    }
}
