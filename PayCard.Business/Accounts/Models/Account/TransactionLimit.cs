using PayCard.Domain.Common;
using PayCard.Domain.Common.Models;
using PayCard.Domain.Accounts.Exceptions;

using static PayCard.Domain.Common.Constants;

namespace PayCard.Domain.Accounts.Models.Account
{
    public class TransactionLimit : ValueObject
    {
        internal TransactionLimit(decimal dailyTransactionsLimit = 0, decimal weeklyTransactionsLimit = 0, decimal monthlyTransactionsLimit = 0)
        {
            Validate(dailyTransactionsLimit, weeklyTransactionsLimit, monthlyTransactionsLimit);

            DailyTransactionsLimit = dailyTransactionsLimit;
            WeeklyTransactionsLimit = weeklyTransactionsLimit;
            MonthlyTransactionsLimit = monthlyTransactionsLimit;
        }

        public decimal DailyTransactionsLimit { get; init; }

        public decimal WeeklyTransactionsLimit { get; init; }

        public decimal MonthlyTransactionsLimit { get; init; }

        private static void Validate(decimal dailyTransactionsLimit, decimal weeklyTransactionsLimit, decimal monthlyTransactionsLimit)
        {
            Guard.AgainstNegativeNumber<InvalidTransactionLimitException>(dailyTransactionsLimit);
            Guard.AgainstNegativeNumber<InvalidTransactionLimitException>(weeklyTransactionsLimit);
            Guard.AgainstNegativeNumber<InvalidTransactionLimitException>(monthlyTransactionsLimit);

            Guard.AgainstOutOfRange<InvalidTransactionLimitException>(
                dailyTransactionsLimit,
                Numeric.Zero,
                Constants.Account.DailyTransactionsLimit,
                nameof(DailyTransactionsLimit));

            Guard.AgainstOutOfRange<InvalidTransactionLimitException>(
               weeklyTransactionsLimit,
               Numeric.Zero,
               Constants.Account.WeeklyTransactionsLimit,
               nameof(WeeklyTransactionsLimit));

            Guard.AgainstOutOfRange<InvalidTransactionLimitException>(
                monthlyTransactionsLimit,
                Numeric.Zero,
                Constants.Account.MonthlyTransactionsLimit,
                nameof(MonthlyTransactionsLimit));
        }
    }
}
