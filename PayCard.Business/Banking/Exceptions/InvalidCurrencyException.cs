using PayCard.Domain.Common;

namespace PayCard.Domain.Banking.Exceptions
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
