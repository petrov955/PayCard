namespace PayCard.Domain.Common
{
    public abstract class BaseDomainException : Exception
    {
        private string? error;

        public string Error
        {
            get => error ?? base.Message;
            set => error = value;
        }
    }
}
