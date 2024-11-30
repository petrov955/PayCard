using System.Text.RegularExpressions;

using PayCard.Domain.Common;
using PayCard.Domain.Common.Resources;
using PayCard.Domain.Common.Contracts;
using PayCard.Domain.Common.Models;
using PayCard.Domain.Accounts.Exceptions;

using static PayCard.Domain.Common.Constants.Account;

namespace PayCard.Domain.Accounts.Models.Account
{
    public class Account : Entity<long>, IAggregateRoot
    {
        internal Account(
            string IBAN,
            string swiftOrBIC,
            string beneficiary,
            string accountDescription,
            decimal balance,
            Currency currency,
            string bankName,
            TransactionLimit transactionLimit,
            bool isActive = true)
        {
            Validate(IBAN, swiftOrBIC, accountDescription, balance, bankName, beneficiary);

            this.IBAN = IBAN;
            SwiftOrBIC = swiftOrBIC;
            Beneficiary = beneficiary;
            AccountDescription = accountDescription;
            Balance = balance;
            Currency = currency;
            BankName = bankName;
            TransactionLimit = transactionLimit;
            IsActive = isActive;
        }

        public string AccountDescription { get; private set; }

        public decimal Balance { get; private set; }

        public Currency Currency { get; init; }

        public string IBAN { get; private set; }

        public string SwiftOrBIC { get; private set; }

        public string BankName { get; private set; }

        public string Beneficiary { get; init; }

        public TransactionLimit TransactionLimit { get; private set; }

        public bool IsActive { get; private set; }

        public void UpdateAccountDescription(string accountDescription)
        {
            Guard.ForStringLength<InvalidAccountException>(accountDescription, MinDescriptionLength, MaxDescriptionLength, nameof(AccountDescription));
            AccountDescription = accountDescription;
        }

        public void UpdateBalance(decimal balance)
        {
            Guard.AgainstOutOfRange<InvalidAccountException>(balance, MinBalance, MaxBalance, nameof(Balance));
            Balance = balance;
        }

        public void UpdateBankName(string bankName)
        {
            Guard.ForStringLength<InvalidAccountException>(bankName, MinBankNameLength, MaxBankNameLength, nameof(BankName));
            BankName = bankName;
        }

        public void UpdateIBAN(string IBAN)
        {
            ValidateIBAN(IBAN);
            this.IBAN = IBAN;
        }

        public void UpdateSwift(string swiftOrBIC)
        {
            ValidateSwift(swiftOrBIC);
            SwiftOrBIC = swiftOrBIC;
        }

        public void ChangeLimits(TransactionLimit transactionLimits)
        {
            TransactionLimit = transactionLimits;
        }

        private void ValidateIBAN(string IBAN)
        {
            var regex = new Regex(Constants.RegexPattern.IBAN);
            if (!regex.IsMatch(IBAN))
            {
                throw new InvalidAccountException(Global.InvalidAccountIBAN);
            }
        }

        private void ValidateSwift(string swift)
        {
            var regex = new Regex(Constants.RegexPattern.Swift);
            if (!regex.IsMatch(swift))
            {
                throw new InvalidAccountException(Global.InvalidAccountSwift);
            }
        }

        private void Validate(
            string IBAN,
            string swiftOrBIC,
            string accountDescription,
            decimal balance,
            string bankName,
            string beneficiary)
        {
            Guard.ForStringLength<InvalidAccountException>(accountDescription, MinDescriptionLength, MaxDescriptionLength, nameof(AccountDescription));
            Guard.AgainstOutOfRange<InvalidAccountException>(balance, MinBalance, MaxBalance, nameof(Balance));
            Guard.ForStringLength<InvalidAccountException>(bankName, MinBankNameLength, MaxBankNameLength, nameof(BankName));
            Guard.ForStringLength<InvalidAccountException>(beneficiary, MinBeneficiaryLength, MaxBeneficiaryLength, nameof(Beneficiary));
            ValidateIBAN(IBAN);
            ValidateSwift(swiftOrBIC);
        }
    }
}
