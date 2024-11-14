using PayCard.Domain.Common;
using PayCard.Domain.Finance.Enums;
using PayCard.Domain.Finance.Models;
using PayCard.Domain.Finance.ValueObjects;

namespace PayCard.Domain.Finance.Factories
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
