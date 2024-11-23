namespace PayCard.Application.Common
{
    public abstract class SortOrder
    {
        public const string Ascending = "asc";

        public const string Descending = "desc";

        protected SortOrder(string? sortBy, string? order = Ascending)
        {
            SortBy = sortBy;
            Order = order;
        }

        public string? SortBy { get; }

        public string? Order { get; }
    }
}
