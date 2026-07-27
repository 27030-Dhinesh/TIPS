using System.Text.RegularExpressions;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Provides reusable utility methods for data validation.
    /// </summary>
    internal static partial class ValidationHelper
    {
        /// <summary>
        /// Validates whether a specified name meets the required naming rules for products.
        /// </summary>
        /// <param name="name">The name string to validate.</param>
        /// <returns>True if name is valid; otherwise, false.</returns>
        public static bool IsValidName(string name)
        {
            if (name is null)
            {
                return false;
            }

            name = name.Trim();
            return name.Length >= 2 && name.Length <= 30 && Regex.IsMatch(name, @"^[a-zA-Z0-9'-]+(?:\s[a-zA-Z0-9'-]+)*$", RegexOptions.Compiled);
        }

        /// <summary>
        /// Validates whether a specific name meets the required naming rules for product ID.
        /// </summary>
        /// <param name="productID">The product ID string to validate.</param>
        /// <returns>True if product ID is valid; otherwise, false.</returns>
        public static bool IsValidId(string productID)
        {
            if (string.IsNullOrWhiteSpace(productID))
            {
                return false;
            }

            return Regex.IsMatch(productID.Trim(), @"^[a-zA-Z]{2,3}-\d{3}$", RegexOptions.Compiled);
        }
    }
}
