﻿using PayCard.Domain.Common;

using static PayCard.Domain.Common.Constants.Numeric;

namespace PayCard.Domain.Finance.Enums
{
    public class Gender : Enumeration
    {
        public static Gender Male = new Gender(One, nameof(Male));
        public static Gender Female = new Gender(Two, nameof(Female));
        public static Gender Other = new Gender(Three, nameof(Other));
        public Gender(int value, string name) : base(value, name)
        {
        }
    }
}
