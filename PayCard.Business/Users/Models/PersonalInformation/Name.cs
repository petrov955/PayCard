using PayCard.Domain.Common.Models;

using static PayCard.Domain.Common.Constants.PI;
using PayCard.Domain.Users.Exceptions;

namespace PayCard.Domain.Users.Models.PersonalInformation
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
