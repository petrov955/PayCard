using PayCard.Domain.Common;

namespace PayCard.Domain.Identity.Exceptions
{
    public class InvalidUserException : BaseDomainException
    {
        public InvalidUserException()
        {
        }

        public InvalidUserException(string message)
        {
            Error = message;
        }
    }
}
