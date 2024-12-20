﻿using PayCard.Domain.Common.Contracts;
using PayCard.Domain.Accounts.Models.Account;

namespace PayCard.Domain.Accounts.Factories
{
    public interface IAccountFactory : IFactory<Models.Account.Account>
    {
        IAccountFactory WithIBAN(string iban);

        IAccountFactory WithSwiftOrBIC(string swiftOrBic);

        IAccountFactory WithBeneficiary(string beneficiary);

        IAccountFactory WithAccountDescription(string accountDescription);

        IAccountFactory WithBalance(decimal balance);

        IAccountFactory WithCurrency(Models.Account.Currency currency);

        IAccountFactory WithBankName(string bankName);

        IAccountFactory WithTransactionLimit(TransactionLimit transactionLimit);
    }
}
