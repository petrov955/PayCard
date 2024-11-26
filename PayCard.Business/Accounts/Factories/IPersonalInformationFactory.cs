using PayCard.Domain.Common.Contracts;
using PayCard.Domain.Accounts.Enums;
using PayCard.Domain.Accounts.Models;
using PayCard.Domain.Accounts.Models.PersonalInformation;

namespace PayCard.Domain.Accounts.Factories
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
