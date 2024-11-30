using PayCard.Domain.Common.Models;

using static PayCard.Domain.Common.Constants.Numeric;

namespace PayCard.Domain.Banking.Enums
{
    public class TransactionType : Enumeration
    {
        public static readonly TransactionType Deposit = new TransactionType(One, nameof(Deposit));
        public static readonly TransactionType Internal = new TransactionType(Two, nameof(Internal));
        public static readonly TransactionType Payment = new TransactionType(Three, nameof(Payment));
        public static readonly TransactionType Withdrawal = new TransactionType(Four, nameof(Withdrawal));

        public TransactionType(int value, string name) : base(value, name)
        {
        }
    }
}
