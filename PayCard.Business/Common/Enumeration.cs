﻿using System.Collections.Concurrent;
using System.Reflection;

namespace PayCard.Domain.Common
{
    public abstract class Enumeration : IComparable
    {
        private static readonly ConcurrentDictionary<Type, IEnumerable<object>> EnumCache
            = new ConcurrentDictionary<Type, IEnumerable<object>>();

        public int Value { get; }

        public string Name { get; }

        protected Enumeration(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        public override string ToString() => this.Name;

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
        /// The values are cached using <see cref="EnumCache"/> to avoid unnecessary reflection in future calls.
        /// </remarks>
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var type = typeof(T);

            var values = EnumCache.GetOrAdd(type, _ => type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null)!));

            return values.Cast<T>();
        }

        public static T FromValue<T>(int value) where T : Enumeration
            => Parse<T, int>(value, "value", item => item.Value == value);

        public static T FromName<T>(string name) where T : Enumeration
            => Parse<T, string>(name, "name", item => item.Name == name);

        public static string NameFromValue<T>(int value) where T : Enumeration
            => FromValue<T>(value).Name;

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

        private static T Parse<T, TValue>(TValue value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
            }

            return matchingItem;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }

            var typeMatches = this.GetType() == obj.GetType();
            var valueMatches = this.Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => (this.GetType().ToString() + this.Value).GetHashCode();

        public int CompareTo(object? other) => this.Value.CompareTo(((Enumeration)other!).Value);
    }
}
