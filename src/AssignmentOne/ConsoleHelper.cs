using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AssignmentOne.Models;

namespace AssignmentOne
{
    /// <summary>
    /// Helper methods for Console operations.
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Get valid string input from user.
        /// </summary>
        /// <param name="prompt">Text to display before input.</param>
        /// <returns>Valid string value.</returns>
        public static string GetInput(string prompt)
        {
            string? input;
            while (true)
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        /// <summary>
        /// Print a contact object legibly.
        /// </summary>
        /// <param name="contact">ContactInfo instance to print.</param>
        public static void PrintContact(ContactInfo contact)
        {
            Console.WriteLine($"ID: {contact.Id}");
            Console.WriteLine($"Name: {contact.Name}");
            Console.WriteLine($"Phone: {contact.Phone}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Notes: {contact.Notes}");
        }

        /// <summary>
        /// Print edit message for given category.
        /// </summary>
        /// <param name="category">Category of Edit Message display.</param>
        public static void EditMessage(string category)
        {
            Console.WriteLine($"Do you want to edit {category} [Y]? (empty to leave as it is)");
        }

        /// <summary>
        /// Print data not found.
        /// </summary>
        public static void DisplayEmpty()
        {
            Console.WriteLine("No data found.");
        }

        /// <summary>
        /// Print app functionalities.
        /// </summary>
        public static void DisplayAppInfo()
        {
            Console.WriteLine("======Contact Manager======");
            Console.WriteLine("1. Add a new contact.");
            Console.WriteLine("2. Edit a contact.");
            Console.WriteLine("3. Delete a contact");
            Console.WriteLine("4. Show all contacts");
            Console.WriteLine("5. Search contact");
            Console.WriteLine("6. Display sorted contacts");
            Console.WriteLine("7. Quit");
        }
    }
}
