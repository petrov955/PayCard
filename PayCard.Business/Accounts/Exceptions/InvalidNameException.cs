using PayCard.Domain.Common;

namespace PayCard.Domain.Accounts.Exceptions
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
