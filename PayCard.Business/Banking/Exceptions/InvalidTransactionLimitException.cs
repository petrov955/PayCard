using PayCard.Domain.Common;

namespace PayCard.Domain.Banking.Exceptions
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
