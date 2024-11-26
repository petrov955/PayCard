using PayCard.Domain.Common;

namespace PayCard.Domain.Accounts.ValueObjects
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
