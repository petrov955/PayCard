using System.Collections.Concurrent;
using System.Reflection;

namespace PayCard.Domain.Common
{
    public abstract class Enumeration : IComparable
    {
        private static readonly ConcurrentDictionary<Type, IEnumerable<object>> _enumCache
            = new ConcurrentDictionary<Type, IEnumerable<object>>();

        protected Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public int Value { get; }

        public string Name { get; }

        /// <summary>
        /// Retrieves all public static fields of the specified type <typeparamref name="T"/> that derive from the <see cref="Enumeration"/> class.
        /// The result is cached to optimize future lookups.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the enumeration, which must derive from the <see cref="Enumeration"/> class.
        /// </typeparam>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing all static instances of the type <typeparamref name="T"/>.
        /// </returns>
        /// <remarks>
        /// This method uses reflection to gather all the public static fields that are defined directly on the type <typeparamref name="T"/>.
        /// The values are cached using <see cref="_enumCache"/> to avoid unnecessary reflection in future calls.
        /// </remarks>
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var type = typeof(T);

            var values = _enumCache.GetOrAdd(type, _ => type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null)!));

            return values.Cast<T>();
        }

        /// <summary>
        /// Retrieves an enumeration instance of type <typeparamref name="T"/> that matches the specified integer value.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration, which must inherit from <see cref="Enumeration"/>.</typeparam>
        /// <param name="value">The integer value associated with the enumeration item to retrieve.</param>
        /// <returns>An instance of <typeparamref name="T"/> that corresponds to the specified integer value.</returns>
        public static T FromValue<T>(int value) where T : Enumeration
        {
            return Parse<T, int>(value, "value", item => item.Value == value);
        }

        private static T Parse<T, TValue>(TValue value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
            }

            return matchingItem;
        }

        /// <summary>
        /// Retrieves an enumeration instance of type <typeparamref name="T"/> that matches the specified name.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration, which must inherit from <see cref="Enumeration"/>.</typeparam>
        /// <param name="name">The name associated with the enumeration item to retrieve.</param>
        /// <returns>An instance of <typeparamref name="T"/> that corresponds to the specified name.</returns>
        public static T FromName<T>(string name) where T : Enumeration
        {
            return Parse<T, string>(name, "name", item => item.Name == name);
        }

        /// <summary>
        /// Retrieves the name of an enumeration instance of type <typeparamref name="T"/> that matches the specified integer value.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration, which must inherit from <see cref="Enumeration"/>.</typeparam>
        /// <param name="value">The integer value associated with the enumeration item whose name is to be retrieved.</param>
        /// <returns>The name of the enumeration item that corresponds to the specified integer value.</returns>
        public static string NameFromValue<T>(int value) where T : Enumeration
        {
            return FromValue<T>(value).Name;
        }

        /// <summary>
        /// Determines whether an enumeration of type <typeparamref name="T"/> contains an item with the specified integer value.
        /// </summary>
        /// <typeparam name="T">The type of the enumeration, which must inherit from <see cref="Enumeration"/>.</typeparam>
        /// <param name="value">The integer value to check for in the enumeration.</param>
        /// <returns>
        /// <c>true</c> if an enumeration item with the specified value exists; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasValue<T>(int value) where T : Enumeration
        {
            try
            {
                FromValue<T>(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Value).GetHashCode();
        }

        public int CompareTo(object? other)
        {
            return Value.CompareTo(((Enumeration)other!).Value);
        }
    }
}
