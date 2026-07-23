using System.Text.RegularExpressions;

namespace BankingSystem
{
    /// <summary>
    /// Static class with validation helper methods to validate data.
    /// </summary>
    internal static class ValidationHelper
    {
        /// <summary>
        /// Check whether the account number is valid or not.
        /// </summary>
        /// <param name="accountNumber">Account number to validate.</param>
        /// <returns>True if account number is valid, false otherwise.</returns>
        public static bool IsValidAccountNumber(string accountNumber)
        {
            return accountNumber.Trim().All(char.IsDigit);
        }

        /// <summary>
        /// Check whether the customer name is valid or not.
        /// </summary>
        /// <param name="name">Name of the customer to validate.</param>
        /// <returns>True if the name is valid, false otherwise.</returns>
        public static bool IsValidName(string name)
        {
            return Regex.IsMatch(name.Trim(), @"^(?=.{2,30}$)\p{L}+(?: \p{L}+)*$");
        }
    }
}
