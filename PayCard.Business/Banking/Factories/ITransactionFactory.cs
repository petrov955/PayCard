using PayCard.Domain.Common.Contracts;
using PayCard.Domain.Banking.Enums;
using PayCard.Domain.Banking.Models.Transaction;

namespace PayCard.Domain.Banking.Factories
{
    public interface ITransactionFactory : IFactory<Transaction>
    {
        ITransactionFactory WithTransactionType(TransactionType transactionType);
        
        ITransactionFactory WithAmount(decimal amount);
        
        ITransactionFactory WithCurrency(Currency currency);
        
        ITransactionFactory WithSourceAccount(Account sourceAccount);
       
        ITransactionFactory WithDestinationAccount(Account destinationAccount);
        
        ITransactionFactory WithStatus(TransactionStatus status);
        
        ITransactionFactory WithNote(string? note);
        
        ITransactionFactory WithExchangeRate(decimal exchangeRate);
       
        ITransactionFactory WithFee(decimal fee);
    }
}