namespace PayCard.Domain.Entities
{
    public class Country
    {
        public long Id { get; set; }
       
        public string Name { get; set; }
        
        public bool IsActive { get; set; }
        
        public long RegionId { get; set; }
        
        public string CountryCode { get; set; }
        
        public string CurrencyCode { get; set; }
    }
}
