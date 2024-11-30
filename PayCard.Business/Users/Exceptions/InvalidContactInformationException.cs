using PayCard.Domain.Common;

namespace PayCard.Domain.Users.Exceptions
{
    public class InvalidContactInformationException : BaseDomainException
    {
        public InvalidContactInformationException()
        {
        }

        public InvalidContactInformationException(string message)
        {
            Error = message;
        }
    }
}
