using PayCard.Domain.Exceptions;

namespace PayCard.Domain.Common
{
    public static class Guard
    {
        private const string DefaultParameterName = "Value";

        /// <summary>
        /// Validates that the provided string is not null or empty.
        /// Throws a specified domain exception if the string is invalid.
        /// </summary>
        /// <typeparam name="TException">
        /// The type of exception to throw if validation fails. 
        /// This exception must inherit from <see cref="BaseDomainException"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="value">The string value to validate.</param>
        /// <param name="name">
        /// An optional parameter that specifies the name of the value being validated.
        /// </param>
        /// <exception cref="TException">
        /// Thrown when the <paramref name="value"/> is null or empty, 
        /// with a message indicating that the <paramref name="name"/> cannot be null or empty.
        /// </exception>
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
        /// <typeparam name="TException">
        /// The type of exception to throw if validation fails. 
        /// This exception must inherit from <see cref="BaseDomainException"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="value">The string value to validate.</param>
        /// <param name="minLength">The minimum allowed length of the string.</param>
        /// <param name="maxLength">The maximum allowed length of the string.</param>
        /// <param name="name">
        /// An optional parameter that specifies the name of the value being validated.
        /// </param>
        /// <exception cref="TException">
        /// Thrown if the <paramref name="value"/> is null, empty, or its length is less than <paramref name="minLength"/> 
        /// or greater than <paramref name="maxLength"/>. The exception message will specify the expected length range.
        /// </exception>
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
        /// <typeparam name="TException">
        /// The type of exception to throw if validation fails. 
        /// This exception must inherit from <see cref="BaseDomainException"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="number">The long value to validate.</param>
        /// <param name="min">The minimum allowable value (inclusive).</param>
        /// <param name="max">The maximum allowable value (inclusive).</param>
        /// <param name="name">
        /// An optional parameter that specifies the name of the value being validated.
        /// </param>
        /// <exception cref="TException">
        /// Thrown when the <paramref name="number"/> is outside the specified range, 
        /// with a message indicating that the <paramref name="name"/> must be between <paramref name="min"/> and <paramref name="max"/>.
        /// </exception>

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
        /// <typeparam name="TException">
        /// The type of exception to throw if validation fails. 
        /// This exception must inherit from <see cref="BaseDomainException"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="number">The decimal value to validate.</param>
        /// <param name="min">The minimum allowable value (inclusive).</param>
        /// <param name="max">The maximum allowable value (inclusive).</param>
        /// <param name="name">
        /// An optional parameter that specifies the name of the value being validated.
        /// </param>
        /// <exception cref="TException">
        /// Thrown when the <paramref name="number"/> is outside the specified range, 
        /// with a message indicating that the <paramref name="name"/> must be between <paramref name="min"/> and <paramref name="max"/>.
        /// </exception>
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
        /// Throws a domain exception of the specified type with a custom error message.
        /// </summary>
        /// <typeparam name="TException">
        /// The type of the exception to throw. 
        /// This exception must inherit from <see cref="BaseDomainException"/> and have a parameterless constructor.
        /// </typeparam>
        /// <param name="message">The custom error message to assign to the exception.</param>
        /// <exception cref="TException">
        /// Thrown with the provided <paramref name="message"/> as the error description.
        /// </exception>
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
