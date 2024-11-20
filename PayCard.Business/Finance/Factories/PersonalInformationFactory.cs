using PayCard.Domain.Finance.Enums;
using PayCard.Domain.Finance.Models;
using PayCard.Domain.Finance.Models.PersonalInformation;

namespace PayCard.Domain.Finance.Factories
{
    public class PersonalInformationFactory : IPersonalInformationFactory
    {
        Name _name = default!;
        Gender _gender = default!;
        DateTime _dob = default;
        ContactInformation _contactInformation = default!;
        Address _address = default!;
        string _additionalInformation = default!;

        public IPersonalInformationFactory WithAdditionalInformation(string additionalInformation)
        {
            _additionalInformation = additionalInformation;
            return this;
        }

        public IPersonalInformationFactory WithAddress(Address address)
        {
            _address = address;
            return this;
        }

        public IPersonalInformationFactory WithContactInformation(ContactInformation contactInformation)
        {
            _contactInformation = contactInformation;
            return this;
        }

        public IPersonalInformationFactory WithDOB(DateTime dob)
        {
            _dob = dob;
            return this;
        }

        public IPersonalInformationFactory WithGender(Gender gender)
        {
            _gender = gender;
            return this;
        }

        public IPersonalInformationFactory WithName(Name name)
        {
            _name = name;
            return this;
        }

        public PersonalInformation Build() => new PersonalInformation(
            _name,
            _gender,
            _dob,
            _address,
            _contactInformation,
            _additionalInformation
            );

        public PersonalInformation Build(
            Name name,
            Gender gender,
            DateTime dob,
            Address address,
            ContactInformation contactInformation,
            string additionalInformation)
        {
            return
                this
                .WithName(name)
                .WithGender(gender)
                .WithDOB(dob)
                .WithAddress(address)
                .WithContactInformation(contactInformation)
                .WithAdditionalInformation(additionalInformation)
                .Build();
        }
    }
}
