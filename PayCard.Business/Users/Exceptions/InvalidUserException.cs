using PayCard.Domain.Common;

namespace PayCard.Domain.Users.Exceptions
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
