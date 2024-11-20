using PayCard.Domain.Common;
using PayCard.Domain.Finance.Enums;
using PayCard.Domain.Finance.Exceptions;

namespace PayCard.Domain.Finance.Models.PersonalInformation
{
    public class PersonalInformation : Entity<int>, IAggregateRoot
    {
        private const byte AdulthoodAge = 18;
        internal PersonalInformation(
            Name name,
            Gender gender,
            DateTime dOB,
            Address address,
            ContactInformation contactInformation,
            string? additionalInformation = default)
        {
            ValidateDOB(dOB);

            Name = name;
            Gender = gender;
            DOB = dOB;
            Address = address;
            ContactInformation = contactInformation;
            AdditionalInformation = additionalInformation;
        }

        public Name Name { get; private set; }

        public Gender Gender { get; init; }

        public DateTime DOB { get; init; }

        public Address Address { get; private set; }

        public ContactInformation ContactInformation { get; private set; }

        public string? AdditionalInformation { get; private set; }

        public void UpdateName(Name name)
        {
            if (Gender.Female != Gender || Name.FirstName != name.FirstName)
            {
                throw new InvalidPersonalInformationException($"Notice: Last name changes are only permitted for females. Thank you for your understanding.");
            }

            Name = name;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public void UpdateContactInformation(ContactInformation contactInformation)
        {
            ContactInformation = contactInformation;
        }

        private void ValidateDOB(DateTime dob)
        {
            if (DateTime.Now.AddYears(-AdulthoodAge) < dob)
            {
                throw new InvalidPersonalInformationException($"Clients under the age of {AdulthoodAge} are unable to create their own financial wallet. We invite you to enjoy the app as a guest until you turn {AdulthoodAge}.");
            }
        }
    }
}
