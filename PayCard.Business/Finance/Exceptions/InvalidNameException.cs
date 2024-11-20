using PayCard.Domain.Common;

namespace PayCard.Domain.Finance.Exceptions
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
