using PayCard.Domain.Common;

namespace PayCard.Domain.Accounts.Exceptions
{
    public class InvalidTransactionLimitException : BaseDomainException
    {
        public InvalidTransactionLimitException()
        {
        }

        public InvalidTransactionLimitException(string message)
        {
            Error = message;
        }
    }
}
