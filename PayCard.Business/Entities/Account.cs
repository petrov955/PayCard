namespace PayCard.Domain.Entities
{
    public class Account
    {
        public long Id { get; set; }
       
        public string AccountDescription { get; set; }
        
        public decimal Balance { get; set; }


    }
}
