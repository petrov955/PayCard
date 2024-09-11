namespace PayCard.Domain.Exceptions
{
    public class InvalidMemberException : BaseDomainException
    {
        public InvalidMemberException()
        {
        }

        public InvalidMemberException(string error)
        {
            this.Error = error;
        }
    }
}
