using PayCard.Domain.Common;

namespace PayCard.Domain.Accounts.Exceptions
{
    public class InvalidAddressException : BaseDomainException
    {
        public InvalidAddressException()
        {
        }

        public InvalidAddressException(string message)
        {
            Error = message;
        }
    }
}
