using PayCard.Domain.Common;
using PayCard.Domain.Exceptions;

using static PayCard.Domain.Common.Constants.Account;

namespace PayCard.Domain.Models
{
    public class Account : Entity<long>
    {
        private readonly HashSet<Transaction> _transactionHistory;
        internal Account(string accountDescription, decimal balance, Currency currency)
        {
            Guard.ForStringLength<InvalidMemberException>(accountDescription, MinDescriptionLength, MaxDescriptionLength, nameof(this.AccountDescription));
            Guard.AgainstOutOfRange<InvalidMemberException>(balance, MinBalance, MaxBalance, nameof(this.Balance));

            this.AccountDescription = accountDescription;
            this.Balance = balance;
            this.Currency = currency;

            this._transactionHistory = new HashSet<Transaction>();
        }

        public long Id { get; private set; }

        public string AccountDescription { get; private set; }

        public decimal Balance { get; private set; }

        public Currency Currency { get; init; }

        public IReadOnlyCollection<Transaction> TransactionHistory => this._transactionHistory.ToList().AsReadOnly();

        public void UpdateAccountDescription(string accountDescription)
        {
            Guard.ForStringLength<InvalidMemberException>(accountDescription, MinDescriptionLength, MaxDescriptionLength, nameof(this.AccountDescription));
            this.AccountDescription = accountDescription;
        }

        public void UpdateBalance(decimal balance)
        {
            Guard.AgainstOutOfRange<InvalidMemberException>(balance, MinBalance, MaxBalance, nameof(this.Balance));
            this.Balance = balance;
        }

    }
}
