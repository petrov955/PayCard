using System.Text.RegularExpressions;
using PayCard.Domain.Common;
using PayCard.Domain.Enums;
using PayCard.Domain.Exceptions;

using static PayCard.Domain.Common.Constants.PI;

namespace PayCard.Domain.Models
{
    public class PersonalInformation : Entity<int>, IAggregateRoot
    {
        private const byte AdulthoodAge = 18;
        public PersonalInformation(string firstName,
            string lastName,
            Gender gender,
            DateTime dOB,
            Address address,
            string phoneNumber,
            string email,
            string additionalInformation)
        {
            Validate(firstName, lastName, email, dOB, phoneNumber);

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DOB = dOB;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            AdditionalInformation = additionalInformation;
        }

        public string FirstName { get; init; }

        public string LastName { get; private set; }

        public Gender Gender { get; init; }

        public DateTime DOB { get; init; }

        public Address Address { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Email { get; private set; }

        public string AdditionalInformation { get; private set; }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public void UpdateEmail(string email)
        {
            ValidateEmail(email);
            Email = email;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            ValidatePhoneNumber(phoneNumber);
            PhoneNumber = phoneNumber;
        }

        private void ValidateEmail(string email)
        {
            Regex regex = new Regex(Constants.RegexPattern.Email);
            if (!regex.IsMatch(email))
            {
                throw new InvalidMemberException("Invalid email format.");
            }
        }

        private void ValidateDOB(DateTime dob)
        {
            if (DateTime.Now.AddYears(-AdulthoodAge) < dob)
            {
                throw new InvalidMemberException($"Clients under the age of {AdulthoodAge} are unable to create their own financial wallet. We invite you to enjoy the app as a guest until you turn {AdulthoodAge}.");
            }
        }

        private void ValidatePhoneNumber(string phoneNumber)
        {
            var regex = new Regex(Constants.RegexPattern.PhoneNumber);
            if (!regex.IsMatch(phoneNumber))
            {
                throw new InvalidMemberException("Invalid phone number format. Please ensure your number follows the example: +1 123-456-7890");
            }
        }

        private void Validate(string firstName, string lastName, string email, DateTime dOB, string phoneNumber)
        {
            Guard.ForStringLength<InvalidMemberException>(firstName, MinNameLength, MaxNameLength, nameof(FirstName));
            Guard.ForStringLength<InvalidMemberException>(lastName, MinNameLength, MaxNameLength, nameof(LastName));
            ValidateEmail(email);
            ValidateDOB(dOB);
            ValidatePhoneNumber(phoneNumber);
        }
    }
}
