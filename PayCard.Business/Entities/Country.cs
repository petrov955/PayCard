namespace PayCard.Domain.Entities
{
    public class Country
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

        //fk to region
        public long RegionId { get; set; }

        public string CountryCode { get; set; }

        //Fk to currencies
        public string CurrencyCode { get; set; }

    }
}
