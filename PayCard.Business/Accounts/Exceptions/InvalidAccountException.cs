using PayCard.Domain.Common;

namespace PayCard.Domain.Accounts.Exceptions
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
