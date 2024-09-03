namespace PayCard.Business.Models
{
    public class User
    {
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        // In the DB foreign key to table Account Types
        public int AccountType { get; set; }
    }
}
