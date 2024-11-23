using PayCard.Domain.Common.Models;
using PayCard.Domain.Finance.Exceptions;

using static PayCard.Domain.Common.Constants.PI;

namespace PayCard.Domain.Finance.Models.PersonalInformation
{
    public class Name : ValueObject
    {
        internal Name(string firstName, string lastName)
        {
            Guard.ForStringLength<InvalidNameException>(firstName, MinNameLength, MaxNameLength, nameof(FirstName));
            Guard.ForStringLength<InvalidNameException>(lastName, MinNameLength, MaxNameLength, nameof(LastName));

            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
