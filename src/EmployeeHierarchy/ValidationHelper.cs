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
        public static bool IsValidName(string name)
        {
            return Regex.IsMatch(name.Trim(), @"^(?=.{2,30}$)\p{L}+(?: \p{L}+)*$");
        }
    }
}
