using PayCard.Domain.Common;

namespace PayCard.Domain.Users.Exceptions
{
    public class InvalidNameException : BaseDomainException
    {
        public InvalidNameException()
        {
        }

        public InvalidNameException(string message)
        {
            Error = message;
        }
    }
}
