using PayCard.Domain.Common;

namespace PayCard.Domain.Finance.Exceptions
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
