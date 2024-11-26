using PayCard.Domain.Accounts.Models.Account;

namespace PayCard.Domain.Accounts.Factories
{
    public class AccountFactory : IAccountFactory
    {
        string _iban = default!;
        string _swiftOrBic = default!;
        string _beneficiary = default!;
        string _accountDescription = default!;
        decimal _balance = default!;
        Currency _currency = default!;
        string _bankName = default!;
        TransactionLimit _transactionLimit = default!;

        public IAccountFactory WithAccountDescription(string accountDescription)
        {
            _accountDescription = accountDescription;
            return this;
        }

        public IAccountFactory WithBalance(decimal balance)
        {
            _balance = balance;
            return this;
        }

        public IAccountFactory WithBankName(string bankName)
        {
            _bankName = bankName;
            return this;
        }

        public IAccountFactory WithBeneficiary(string beneficiary)
        {
            _beneficiary = beneficiary;
            return this;
        }

        public IAccountFactory WithCurrency(Currency currency)
        {
            _currency = currency;
            return this;
        }

        public IAccountFactory WithIBAN(string iban)
        {
            _iban = iban;
            return this;
        }

        public IAccountFactory WithSwiftOrBIC(string swiftOrBic)
        {
            _swiftOrBic = swiftOrBic;
            return this;
        }

        public IAccountFactory WithTransactionLimit(TransactionLimit transactionLimit)
        {
            _transactionLimit = transactionLimit;
            return this;
        }

        public Account Build()
        {
            return new Account(
                _iban,
                _swiftOrBic,
                _beneficiary,
                _accountDescription,
                _balance,
                _currency,
                _bankName,
                _transactionLimit);
        }

        public Account Build(
            string iban,
            string swiftOrBic,
            string beneficiary,
            string accountDescription,
            decimal balance,
            Currency currency,
            string bankName,
            TransactionLimit transactionLimit)
        {
            return
                this
                .WithIBAN(iban)
                .WithSwiftOrBIC(swiftOrBic)
                .WithBeneficiary(beneficiary)
                .WithAccountDescription(accountDescription)
                .WithBalance(balance)
                .WithCurrency(currency)
                .WithBankName(bankName)
                .WithTransactionLimit(transactionLimit)
                .Build();
        }
    }
}
