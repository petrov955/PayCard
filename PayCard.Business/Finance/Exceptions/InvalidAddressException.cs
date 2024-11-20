using PayCard.Domain.Common;

namespace PayCard.Domain.Finance.Exceptions
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
