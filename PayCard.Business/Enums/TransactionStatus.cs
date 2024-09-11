using PayCard.Domain.Common;

using static PayCard.Domain.Common.Constants.Numeric;

namespace PayCard.Domain.Enums
{
    public class TransactionStatus : Enumeration
    {
        public static readonly TransactionStatus Pending = new TransactionStatus(One, nameof(Pending));
        public static readonly TransactionStatus Completed = new TransactionStatus(Two, nameof(Completed));
        public static readonly TransactionStatus Failed = new TransactionStatus(Two, nameof(Failed));
       
        public TransactionStatus(int value, string name) : base(value, name)
        {
        }
    }
}
