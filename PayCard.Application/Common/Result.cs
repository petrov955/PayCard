namespace PayCard.Application.Common
{
    public class Result
    {
        private readonly List<string> _errors;
        internal Result(bool hasError, List<string> errors)
        {
            HasError = hasError;
            _errors = errors;
        }

        public bool HasError { get; }

        public IReadOnlyCollection<string> Errors => HasError
            ? _errors
            : new List<string>();

    }
}
