﻿using PayCard.Domain.Common;

using static PayCard.Domain.Common.Constants.Numeric;

namespace PayCard.Domain.Enums
{
    public class TransactionType : Enumeration
    {
        public static readonly TransactionType Deposit = new TransactionType(One, nameof(Deposit));
        public static readonly TransactionType Internal = new TransactionType(Two, nameof(Internal));
        public static readonly TransactionType External = new TransactionType(Three, nameof(External));
        public static readonly TransactionType Withdrawal = new TransactionType(Four, nameof(Withdrawal));
        public static readonly TransactionType Payment = new TransactionType(Five, nameof(Payment));

        public TransactionType(int value, string name) : base(value, name)
        {
        }

    }
}