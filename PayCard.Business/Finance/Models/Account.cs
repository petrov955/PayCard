using PayCard.Domain.Common;
using PayCard.Domain.Exceptions;
using System.Text.RegularExpressions;

using static PayCard.Domain.Common.Constants.Account;

namespace PayCard.Domain.Finance.Models
{
    public class Account : Entity<long> , IAggregateRoot
    {
        readonly HashSet<Transaction> _transactionHistory;
        
        private Account()
        {
            _transactionHistory = new HashSet<Transaction>();
        }

        internal Account(
            string IBAN,
            string swiftOrBIC,
            string beneficiary,
            string accountDescription,
            decimal balance,
            Currency currency,
            string bankName) : this()
        {
            Validate(IBAN, swiftOrBIC, accountDescription, balance, bankName, beneficiary);

            this.IBAN = IBAN;
            SwiftOrBIC = swiftOrBIC;
            Beneficiary = beneficiary;
            AccountDescription = accountDescription;
            Balance = balance;
            Currency = currency;
            BankName = bankName;
        }

        public string AccountDescription { get; private set; }

        public decimal Balance { get; private set; }

        public Currency Currency { get; init; }

        public string IBAN { get; private set; }

        public string SwiftOrBIC { get; private set; }

        public string BankName { get; private set; }

        public string Beneficiary { get; init; }

        public IReadOnlyCollection<Transaction> TransactionHistory => _transactionHistory.ToList().AsReadOnly();

        public void UpdateAccountDescription(string accountDescription)
        {
            Guard.ForStringLength<InvalidMemberException>(accountDescription, MinDescriptionLength, MaxDescriptionLength, nameof(AccountDescription));
            AccountDescription = accountDescription;
        }

        public void UpdateBalance(decimal balance)
        {
            Guard.AgainstOutOfRange<InvalidMemberException>(balance, MinBalance, MaxBalance, nameof(Balance));
            Balance = balance;
        }

        public void UpdateBankName(string bankName)
        {
            Guard.ForStringLength<InvalidMemberException>(bankName, MinBankNameLength, MaxBankNameLength, nameof(BankName));
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

        private void ValidateIBAN(string IBAN)
        {
            var regex = new Regex(Constants.RegexPattern.IBAN);
            if (!regex.IsMatch(IBAN))
            {
                throw new InvalidMemberException("Invalid IBAN number.");
            }
        }

        private void ValidateSwift(string swift)
        {
            var regex = new Regex(Constants.RegexPattern.Swift);
            if (!regex.IsMatch(swift))
            {
                throw new InvalidMemberException("Invalid Swift code.");
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
            Guard.ForStringLength<InvalidMemberException>(accountDescription, MinDescriptionLength, MaxDescriptionLength, nameof(AccountDescription));
            Guard.AgainstOutOfRange<InvalidMemberException>(balance, MinBalance, MaxBalance, nameof(Balance));
            Guard.ForStringLength<InvalidMemberException>(bankName, MinBankNameLength, MaxBankNameLength, nameof(BankName));
            Guard.ForStringLength<InvalidMemberException>(beneficiary, MinBeneficiaryLength, MaxBeneficiaryLength, nameof(Beneficiary));
            ValidateIBAN(IBAN);
            ValidateSwift(swiftOrBIC);
        }
    }
}
