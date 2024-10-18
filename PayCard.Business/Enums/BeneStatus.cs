using PayCard.Domain.Common;

using static PayCard.Domain.Common.Constants.Numeric;

namespace PayCard.Domain.Enums
{
    public class BeneficiaryStatus : Enumeration
    {
        public static readonly BeneficiaryStatus Active = new BeneficiaryStatus(One, nameof(Active));
        public static readonly BeneficiaryStatus Inactive = new BeneficiaryStatus(Two, nameof(Inactive));

        public BeneficiaryStatus(int value, string name) : base(value, name)
        {
        }
    }
}
