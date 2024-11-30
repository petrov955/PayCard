using PayCard.Domain.Common.Contracts;
using PayCard.Domain.Users.Enums;
using PayCard.Domain.Users.Models.PersonalInformation;

namespace PayCard.Domain.Users.Factories
{
    public interface IPersonalInformationFactory : IFactory<PersonalInformation>
    {
        IPersonalInformationFactory WithName(Name name);

        IPersonalInformationFactory WithGender(Gender gender);

        IPersonalInformationFactory WithDOB(DateTime dob);

        IPersonalInformationFactory WithAddress(Address address);

        IPersonalInformationFactory WithContactInformation(ContactInformation contactInformation);

        IPersonalInformationFactory WithAdditionalInformation(string additionalInformation);
    }
}
