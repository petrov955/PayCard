namespace PayCard.Infrastructure.Database.Models
{
    public class Address
    {
        public int Id { get; set; }

        public int CountryId { get; set; }
       
        public Country Country { get; set; } = default!;
        
        public string City { get; set; } = default!;
       
        public string AddressLine1 { get; set; } = default!;

        public string AddressLine2 { get; set; } = default!;

        public string District { get; set; } = default!;

        public string PostalCode { get; set; } = default!;

        public ICollection<PersonalInformation> PersonalInformation { get; set; } = new HashSet<PersonalInformation>();
    }
}
