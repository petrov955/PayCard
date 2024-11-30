using PayCard.Domain.Common;

namespace PayCard.Domain.Banking.Exceptions
{
    public class InvalidTransactionException : BaseDomainException
    {
        public InvalidTransactionException()
        {
        }

        public InvalidTransactionException(string message)
        {
            Error = message;
        }
    }
}
