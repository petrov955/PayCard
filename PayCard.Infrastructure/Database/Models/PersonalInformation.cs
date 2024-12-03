namespace PayCard.Infrastructure.Database.Models
{
    public class PersonalInformation
    {
        public int Id { get; set; }

        public string FullName { get; private set; } = default!;

        public int GenderId { get; set; }

        public Gender Gender { get; set; } = default!;

        public DateTime DOB { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; private set; } = default!;

        public string EmailAddress { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
    }
}
