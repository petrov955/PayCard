using PayCard.Domain.Common;

namespace PayCard.Domain.Accounts.Exceptions
{
    public class InvalidCurrencyException : BaseDomainException
    {
        public InvalidCurrencyException()
        {
        }

        public InvalidCurrencyException(string message)
        {
            Error = message;
        }
    }
}
