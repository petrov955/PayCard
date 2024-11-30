using PayCard.Domain.Banking.Enums;
using PayCard.Domain.Banking.Models.Transaction;
using static PayCard.Domain.Common.Constants.Transaction;

namespace PayCard.Domain.Banking.Factories
{
    public class TransactionFactory : ITransactionFactory
    {
        TransactionType _transactionType = default!;
        decimal _amount = default;
        Currency _currency = default!;
        Account _sourceAccount = default!;
        Account _destinationAccount = default!;
        TransactionStatus _status = default!;
        string? _note = default;
        decimal _exchangeRate;
        decimal _fee = default;

        public ITransactionFactory WithAmount(decimal amount)
        {
            _amount = amount;
            return this;
        }

        public ITransactionFactory WithCurrency(Currency currency)
        {
            _currency = currency;
            return this;
        }

        public ITransactionFactory WithDestinationAccount(Account destinationAccount)
        {
            _destinationAccount = destinationAccount;
            return this;
        }

        public ITransactionFactory WithExchangeRate(decimal exchangeRate = DefaultExchangeRate)
        {
            _exchangeRate = exchangeRate;
            return this;
        }

        public ITransactionFactory WithFee(decimal fee = DefaultFee)
        {
            _fee = fee;
            return this;
        }

        public ITransactionFactory WithNote(string? note)
        {
            _note = note;
            return this;
        }

        public ITransactionFactory WithSourceAccount(Account sourceAccount)
        {
            _sourceAccount = sourceAccount;
            return this;
        }

        public ITransactionFactory WithStatus(TransactionStatus status)
        {
            _status = status;
            return this;
        }

        public ITransactionFactory WithTransactionType(TransactionType transactionType)
        {
            _transactionType = transactionType;
            return this;
        }

        public Transaction Build()
        {
            return new Transaction(
                _transactionType,
                _amount,
                _currency,
                _sourceAccount,
                _destinationAccount,
                _status,
                _note,
                _exchangeRate,
                _fee);
        }

        public Transaction Build(
             TransactionType transactionType,
            decimal amount,
            Currency currency,
            Account sourceAccount,
            Account destinationAccount,
            TransactionStatus status,
            string? note,
            decimal exchangeRate,
            decimal fee
            )
        {
            return 
                this
                .WithTransactionType(transactionType)
                .WithAmount(amount)
                .WithCurrency(currency)
                .WithSourceAccount(sourceAccount)
                .WithDestinationAccount(destinationAccount)
                .WithStatus(status)
                .WithNote(note)
                .WithExchangeRate(exchangeRate)
                .WithFee(fee)
                .Build();
        }
    }
}
