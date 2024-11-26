using PayCard.Domain.Common;

namespace PayCard.Domain.Accounts.Exceptions
{
    public class InvalidPersonalInformationException : BaseDomainException
    {
        public InvalidPersonalInformationException()
        {
        }

        public InvalidPersonalInformationException(string message)
        {
            Error = message;
        }
    }
}
