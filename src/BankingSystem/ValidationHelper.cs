using System.Text.RegularExpressions;

namespace BankingSystem
{
    /// <summary>
    /// Static class with validation helper methods to validate data.
    /// </summary>
    internal static class ValidationHelper
    {
        /// <summary>
        /// Check whether the customer name is valid or not.
        /// </summary>
        /// <param name="name">Name of the customer to validate.</param>
        /// <returns>True if the name is valid, false otherwise.</returns>
        public static bool IsValidName(string? name)
        {
            if (name is null)
            {
                return false;
            }

            name = name.Trim();
            return name.Length >= 2
                && name.Length <= 30
                && Regex.IsMatch(name, @"^[a-zA-Z0-9'-]+(?:\s[a-zA-Z0-9'-]+)*$", RegexOptions.Compiled);
        }

        /// <summary>
        /// Check whether the account number is valid or not.
        /// </summary>
        /// <param name="accountNumber">Account number to validate.</param>
        /// <returns>True if account number is valid, false otherwise.</returns>
        public static bool IsValidAccountNumber(string? accountNumber)
        {
            if (accountNumber is null)
            {
                return false;
            }

            accountNumber = accountNumber.Trim();
            return accountNumber.Length == 12 && accountNumber.All(char.IsDigit);
        }
    }
}
