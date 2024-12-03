namespace PayCard.Infrastructure.Database.Models
{
    public class Gender
    {
        public int Id { get; set; }

        public string Type { get; set; } = default!;

        public ICollection<PersonalInformation> PersonalInformation { get; set; } = new HashSet<PersonalInformation>();
    }
}
