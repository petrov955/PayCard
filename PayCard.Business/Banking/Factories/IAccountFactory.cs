using PayCard.Domain.Common.Contracts;
using PayCard.Domain.Banking.Models.Account;

namespace PayCard.Domain.Banking.Factories
{
    public interface IAccountFactory : IFactory<Account>
    {
        IAccountFactory WithIBAN(string iban);

        IAccountFactory WithSwiftOrBIC(string swiftOrBic);

        IAccountFactory WithBeneficiary(string beneficiary);

        IAccountFactory WithAccountDescription(string accountDescription);

        IAccountFactory WithBalance(decimal balance);

        IAccountFactory WithCurrency(Currency currency);

        IAccountFactory WithBankName(string bankName);

        IAccountFactory WithTransactionLimit(TransactionLimit transactionLimit);
    }
}
