using PayCard.Domain.Common;

using static PayCard.Domain.Common.Constants.Numeric;

namespace PayCard.Domain.Enums
{
    public class CostType : Enumeration
    {
        public static readonly CostType Grocery = new CostType(One, nameof(Grocery));
        public static readonly CostType Health = new CostType(Two, nameof(Health));
        public static readonly CostType Investment = new CostType(Three, nameof(Investment));
        public static readonly CostType Bills = new CostType(Four, nameof(Bills));
        public static readonly CostType Activities = new CostType(Five, nameof(Activities));
        public static readonly CostType Travel = new CostType(Six, nameof(Travel));

        public CostType(int value, string name) : base(value, name)
        {
        }
    }
}
