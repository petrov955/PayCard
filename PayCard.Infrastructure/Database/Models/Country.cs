namespace PayCard.Infrastructure.Database.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; private set; } = default!;

        public string ISO3166Code { get; private set; } = default!;

        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
