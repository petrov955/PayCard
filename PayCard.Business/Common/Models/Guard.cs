using static PayCard.Domain.Common.Constants.Numeric;

namespace PayCard.Domain.Common.Models
{
    public static class Guard
    {
        private const string DefaultParameterName = "Value";

        /// <summary>
        /// Validates that the provided string is not null or empty.
        /// Throws a specified domain exception if the string is invalid.
        /// </summary>
        /// <exception cref="TException"></exception>
        public static void AgainstEmptyString<TException>(string value, string name = DefaultParameterName)
            where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null or empty.");
        }

        /// <summary>
        /// Validates that the provided string has a length within the specified range (inclusive).
        /// Throws a specified domain exception if the string is either null, empty, or its length is outside the given bounds.
        /// </summary>
        /// <exception cref="TException"></exception>
        public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = DefaultParameterName)
           where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        /// <summary>
        /// Validates that the given long is within the specified range.
        /// Throws a specified domain exception if the long is outside the defined bounds.
        /// </summary>
        /// <exception cref="TException"></exception>

        public static void AgainstOutOfRange<TException>(long number, long min, long max, string name = DefaultParameterName)
          where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        /// <summary>
        /// Validates that the given decimal is within the specified range.
        /// Throws a specified domain exception if the decimal is outside the defined bounds.
        /// </summary>
        /// <exception cref="TException"></exception>
        public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = DefaultParameterName)
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        /// <summary>
        /// Throws a specified exception if the given <paramref name="number"/> is less than or equal to zero.
        /// </summary>
        /// <exception cref="TException"></exception>
        public static void AgainstNegativeNumber<TException>(decimal number)
            where TException : BaseDomainException, new()
        {
            if (number > Zero)
            {
                return;
            }

            ThrowException<TException>($"Please note, your input ({number}) should be greater than {Zero}.");
        }

        /// <summary>
        /// Throws a specified exception if the given <paramref name="number"/> is less than or equal to zero.
        /// </summary>
        /// <exception cref="TException"></exception>
        public static void AgainstNegativeNumber<TException>(long number)
            where TException : BaseDomainException, new()
        {
            if (number > Zero)
            {
                return;
            }

            ThrowException<TException>($"Please note, your input ({number}) should be greater than {Zero}.");
        }

        /// <summary>
        /// Throws a domain exception of the specified type with a custom error message.
        /// </summary>
        /// <exception cref="TException"></exception>
        private static void ThrowException<TException>(string message)
           where TException : BaseDomainException, new()
        {
            var exception = new TException
            {
                Error = message
            };

            throw exception;
        }
    }
}