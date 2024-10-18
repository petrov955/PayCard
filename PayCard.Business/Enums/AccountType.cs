using PayCard.Domain.Common;

using static PayCard.Domain.Common.Constants.Numeric;

namespace PayCard.Domain.Enums
{
    public class  AccountType : Enumeration
    {
        public static readonly AccountType Admin = new AccountType(One, nameof(Admin));
        public static readonly AccountType Guest = new AccountType(Two, nameof(Guest));
        public static readonly AccountType User = new AccountType(Three, nameof(User));

        public AccountType(int value, string name) : base(value, name)
        {
        }
    }
}
