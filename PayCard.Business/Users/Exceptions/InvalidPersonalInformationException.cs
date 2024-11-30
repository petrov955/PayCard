using PayCard.Domain.Common;

namespace PayCard.Domain.Users.Exceptions
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
