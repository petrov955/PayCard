using System.Text.RegularExpressions;
using PayCard.Domain.Common.Models;
using PayCard.Domain.Common.Resources;
using PayCard.Domain.Common;

using static PayCard.Domain.Common.Constants.Account;
using PayCard.Domain.Banking.Exceptions;

namespace PayCard.Domain.Banking.Models.Transaction
{
    public class Account : Entity<long>
    {
        internal Account(
            string IBAN,
            string beneficiary,
            Currency currency,
            string bankName)
        {
            Guard.ForStringLength<InvalidAccountException>(bankName, MinBankNameLength, MaxBankNameLength, nameof(BankName));
            Guard.ForStringLength<InvalidAccountException>(beneficiary, MinBeneficiaryLength, MaxBeneficiaryLength, nameof(Beneficiary));
            ValidateIBAN(IBAN);

            this.IBAN = IBAN;
            Beneficiary = beneficiary;
            Currency = currency;
            BankName = bankName;
        }

        public Currency Currency { get; init; }

        public string IBAN { get; private set; }

        public string BankName { get; private set; }

        public string Beneficiary { get; init; }

        private void ValidateIBAN(string IBAN)
        {
            var regex = new Regex(Constants.RegexPattern.IBAN);
            if (!regex.IsMatch(IBAN))
            {
                throw new InvalidAccountException(Global.InvalidAccountIBAN);
            }
        }
    }
}
