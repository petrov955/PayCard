using PayCard.Domain.Common;
using PayCard.Domain.Finance.Models;

namespace PayCard.Domain.Finance.Factories
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
    }
}
