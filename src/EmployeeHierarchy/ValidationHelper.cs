using System.Text.RegularExpressions;

namespace EmployeeHierarchy
{
    /// <summary>
    /// Helper methods for input validation.
    /// </summary>
    internal class ValidationHelper
    {
        /// <summary>
        /// Check whether the name is valid or not.
        /// </summary>
        /// <param name="name">Name of the contact to validate.</param>
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
    }
}
