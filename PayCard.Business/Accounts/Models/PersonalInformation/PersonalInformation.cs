using PayCard.Domain.Common.Contracts;
using PayCard.Domain.Common.Models;
using PayCard.Domain.Common.Resources;
using PayCard.Domain.Accounts.Enums;
using PayCard.Domain.Accounts.Exceptions;

namespace PayCard.Domain.Accounts.Models.PersonalInformation
{
    public class PersonalInformation : Entity<int>, IAggregateRoot
    {
        private const byte AdulthoodAge = 18;
        private const byte OldestEverLivedPersonAge = 122;
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
                throw new InvalidPersonalInformationException(String.Format(Global.PersonalNameUpdateFailed, Gender.Female.Name));
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
                throw new InvalidPersonalInformationException(String.Format(Global.MinorsCannotCreateAccount, AdulthoodAge, AdulthoodAge));
            }

            var isDOBExceedingHumanLifespan = DateTime.UtcNow.Year - dob.Year > OldestEverLivedPersonAge;
            var isDOBFutureDate = DateTime.UtcNow <= dob;
            if (isDOBFutureDate || isDOBExceedingHumanLifespan)
            {
                throw new InvalidPersonalInformationException(Global.InvalidDOB);
            }
        }
    }
}
