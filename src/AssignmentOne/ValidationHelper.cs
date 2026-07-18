using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AssignmentOne
{
    /// <summary>
    /// Helper methods for input validation.
    /// </summary>
    internal static class ValidationHelper
    {
        /// <summary>
        /// Check if the phone arg is valid or not.
        /// </summary>
        /// <param name="phone">Phone (string) to validate.</param>
        /// <returns>true if phone is valid, false otherwise.</returns>
        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone.Trim(), @"^(?:\+91|0)?[6-9]\d{9}$");
        }

        /// <summary>
        /// Check if the email arg is valid or not.
        /// </summary>
        /// <param name="email">Email (string) to validate.</param>
        /// <returns>true if email is valid, false otherwise.</returns>
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Check whether the name is valid or not.
        /// </summary>
        /// <param name="name">Name of the contact to validate.</param>
        /// <returns>True if the name is valid, false otherwise.</returns>
        public static bool IsValidName(string name)
        {
            if (name.Length < 2 || name.Length > 30 || !name.All(char.IsLetter))
            {
                return false;
            }

            return true;
        }
    }
}
