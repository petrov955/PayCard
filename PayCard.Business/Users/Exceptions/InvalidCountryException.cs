using PayCard.Domain.Common;

namespace PayCard.Domain.Users.Exceptions
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
