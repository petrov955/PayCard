using PayCard.Business.Nomenclature;

namespace PayCard.Business.Models
{
    public class Beneficiary
    {
        public long Id { get; set; }

        #region BankDetails
        public string AccountDescription { get; set; }

        public string BankAddressLine1 { get; set; }

        public string BankAddressLine2 { get; set; }

        public string BankCity { get; set; }

        public string BankCountryId { get; set; }

        public string BankName { get; set; }

        public string BankZipOrPostalCode { get; set; }

        public string BankDistrict { get; set; }
        #endregion

        #region BeneDetails

        public string BeneAccountNumber { get; set; }

        public string BeneAddressLine1 { get; set; }

        public string BeneAddressLine2 { get; set; }

        public string BeneCity { get; set; }

        public string BeneSwift { get; set; }

        public string BeneIban { get; set; }

        public string BeneCountryId { get; set; }

        public string BeneName { get; set; }

        public string BeneZipOrPostalCode { get; set; }

        public string BeneDistrict { get; set; }

        public BeneStatus BeneStatus { get; set; }

        #endregion

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
