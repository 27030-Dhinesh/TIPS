using static InventoryManagementSystem.ValidationHelper;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Provides reusable utility methods for managing user interaction in console applications.
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Display app menu for user choices.
        /// </summary>
        public static void DisplayAppInfo()
        {
            Console.WriteLine($@"1. Add new product
2. Edit product
3. Search product by name
4. Search product by product ID
5. Display all products
6. Delete a product by product ID
7. Exit");
        }

        /// <summary>
        /// Prompts the user via the console and repeatedly reads input until a non-empty, non-whitespace string is provided.
        /// </summary>
        /// <param name="prompt">The message displayed to the user before requesting input.</param>
        /// <param name="errorMessage">The error message displayed when the user enters an invalid (empty or whitespace) string.</param>
        /// <returns>A valid, non-empty <see cref="string"/> entered by the user.</returns>
        public static string GetInput(string prompt, string errorMessage)
        {
            string? choice;
            do
            {
                Console.WriteLine(prompt);
                choice = Console.ReadLine();
                if (string.IsNullOrEmpty(choice) || string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return choice;
                }
            }
            while (true);
        }

        /// <summary>
        /// Prompts the user via the console to enter a price and validates the input.
        /// </summary>
        /// <param name="prompt">The text message displayed to request price input from the user.</param>
        /// <param name="formatErrorMessage">The text message displayed when the input cannot be parsed as a decimal.</param>
        /// <returns>The valid <see cref="decimal"/> price value entered by the user.</returns>
        /// <remarks>
        /// This method repeats the prompt indefinitely until the user inputs a valid decimal formatting string.
        /// </remarks>
        public static decimal GetPrice(string prompt, string formatErrorMessage)
        {
            do
            {
                Console.WriteLine(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    if (amount >= 0)
                    {
                        return amount;
                    }
                    else
                    {
                        Console.WriteLine("Price of the product should be positive.");
                    }
                }
                else
                {
                    Console.WriteLine(formatErrorMessage);
                }
            }
            while (true);
        }

        /// <summary>
        /// Prompts the user via the console to enter a product ID and validates the input.
        /// </summary>
        /// <param name="prompt">The text message displayed to request ID input from the user.</param>
        /// <param name="formatErrorMessage">The error message displayed when the user enters an invalid string.</param>
        /// <returns>The valid <see cref="string"/> price value entered by the user.</returns>
        /// <remarks>
        /// This method repeats the prompt indefinitely until the user inputs a valid product ID string.
        /// </remarks>
        public static string GetProductID(string prompt, string formatErrorMessage)
        {
            string? id;
            do
            {
                Console.WriteLine(prompt);
                id = Console.ReadLine();
                if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id) || !IsValidId(id))
                {
                    Console.WriteLine(formatErrorMessage);
                    continue;
                }

                return id;
            }
            while (true);
        }
    }
}
