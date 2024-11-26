using PayCard.Domain.Common;

namespace PayCard.Domain.Accounts.Exceptions
{
    public class InvalidCountryException : BaseDomainException
    {
        public InvalidCountryException()
        {
        }

        public InvalidCountryException(string message)
        {
            Error = message;
        }
    }
}
