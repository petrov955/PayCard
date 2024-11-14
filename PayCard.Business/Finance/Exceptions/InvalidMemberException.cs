using PayCard.Domain.Common;

namespace PayCard.Domain.Exceptions
{
    public class InvalidMemberException : BaseDomainException
    {
        public InvalidMemberException()
        {
        }

        public InvalidMemberException(string error)
        {
            Error = error;
        }
    }
}
