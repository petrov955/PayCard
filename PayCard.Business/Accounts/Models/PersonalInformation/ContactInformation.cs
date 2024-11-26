using System.Text.RegularExpressions;
using PayCard.Domain.Common;
using PayCard.Domain.Common.Models;
using PayCard.Domain.Accounts.ValueObjects;

namespace PayCard.Domain.Accounts.Models.PersonalInformation
{
    public class ContactInformation : ValueObject
    {
        internal ContactInformation(string phoneNumber, string email)
        {
            ValidateEmail(email);
            ValidatePhoneNumber(phoneNumber);

            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string PhoneNumber { get; }

        public string Email { get; }

        private void ValidateEmail(string email)
        {
            Regex regex = new Regex(Constants.RegexPattern.Email);
            if (!regex.IsMatch(email))
            {
                throw new InvalidContactInformationException("Invalid email format.");
            }
        }

        private void ValidatePhoneNumber(string phoneNumber)
        {
            var regex = new Regex(Constants.RegexPattern.PhoneNumber);
            if (!regex.IsMatch(phoneNumber))
            {
                throw new InvalidContactInformationException("Invalid phone number format. Please ensure your number follows the example: +1 123-456-7890");
            }
        }
    }
}
