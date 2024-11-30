using System.Text;
using PayCard.Domain.Common.Models;
using PayCard.Domain.Users.Enums;
using PayCard.Domain.Users.Exceptions;

using static PayCard.Domain.Common.Constants.User;

namespace PayCard.Domain.Users.Models
{
    public class User : Entity<long>
    {
        internal User(string username, string password, AccountType rights)
        {
            Guard.ForStringLength<InvalidUserException>(username, MinUsernameLength, MaxUsernameLength, nameof(Username));
            ValidatePassword(password);

            Username = username;
            Password = password;
            Rights = rights;
        }

        public string Username { get; init; }

        public AccountType Rights { get; private set; }

        public string Password { get; private set; }

        public string Email { get; private set; }

        public void UpdatePassword(string newPassword)
        {
            ValidatePassword(newPassword);
            Password = newPassword;
        }

        private void ValidatePassword(string password)
        {
            var passwordBytesLength = Encoding.Unicode.GetBytes(password).Length;
            if (passwordBytesLength > MaxPasswordBytesSize || MinPasswordBytesSize > passwordBytesLength)
            {
                throw new InvalidUserException($"Password must be between {MinPasswordBytesSize} and {MaxPasswordBytesSize} Unicode bytes length.");
            }

            var lower = false;
            var upper = false;
            var number = false;
            var special = false;

            foreach (var c in password)
            {
                if (char.IsDigit(c))
                {
                    number = true;
                }
                else if (char.IsLower(c))
                {
                    lower = true;
                }
                else if (char.IsUpper(c))
                {
                    upper = true;
                }
                else
                {
                    special = true;
                }
            }

            if (!(lower && upper && number && special))
            {
                throw new InvalidUserException($"Please, ensure your password contains at least one (upper,lower,digit,special symbol).");
            }
        }

        private void UpdateRights(AccountType rights)
        {
            Rights = rights;
        }
    }
}
