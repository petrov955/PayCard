namespace PayCard.Business.Models.Common
{
    public class Country
    {
        public long Id { get; set; }

        public string CommonName { get; set; }

        public string FormalName { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

        //fk to region
        public long RegionId { get; set; }

        public string CountryCode { get; set; }

        //Fk to currencies
        public string CurrencyCode { get; set; }

    }
}
