using PayCard.Domain.Common;

namespace PayCard.Domain.Banking.Exceptions
{
    public class InvalidAccountException : BaseDomainException
    {
        public InvalidAccountException()
        {
        }

        public InvalidAccountException(string message)
        {
            Error = message;
        }
    }
}
