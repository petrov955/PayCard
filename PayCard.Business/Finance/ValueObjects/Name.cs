using PayCard.Domain.Common;
using PayCard.Domain.Exceptions;

using static PayCard.Domain.Common.Constants.PI;

namespace PayCard.Domain.Finance.Models
{
    public class Name : ValueObject
    {
        internal Name(string firstName, string lastName)
        {
            Guard.ForStringLength<InvalidMemberException>(firstName, MinNameLength, MaxNameLength, nameof(FirstName));
            Guard.ForStringLength<InvalidMemberException>(lastName, MinNameLength, MaxNameLength, nameof(LastName));

            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
