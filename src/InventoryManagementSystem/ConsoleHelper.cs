using InventoryManagementSystem.Models;
using Spectre.Console;
using static System.ConsoleColor;
using static InventoryManagementSystem.ValidationHelper;

namespace InventoryManagementSystem
{
    /// <summary>
    /// Provides reusable utility methods for managing user interaction in console applications.
    /// </summary>
    internal static class ConsoleHelper
    {
        private const int TRIES = 3;

        /// <summary>
        /// Display app menu for user choices.
        /// </summary>
        public static void DisplayAppInfo()
        {
            Console.ForegroundColor = Green;
            Console.WriteLine($@"1. Add new product
2. Edit product
3. Search product by name
4. Search product by product ID
5. Display all products by id
6. Display all products by name
7. Delete a product by product ID
8. Exit
");
            Console.ResetColor();
        }

        /// <summary>
        /// Prompts the user via the console to enter a price and validates the input.
        /// </summary>
        /// <param name="prompt">The text message displayed to request price input from the user.</param>
        /// <param name="formatErrorMessage">The text message displayed when the input cannot be parsed as a positive decimal.</param>
        /// <param name="promptColor">The color used for prompt foreground.</param>
        /// <param name="errorColor">The color used for error message foreground.</param>
        /// <returns>The valid <see cref="decimal"/> price value entered by the user.</returns>
        /// <remarks>
        /// This method repeats the prompt indefinitely until the user inputs a valid decimal formatting string.
        /// </remarks>
        public static decimal GetPrice(
            string prompt,
            string formatErrorMessage,
            ConsoleColor promptColor = Blue,
            ConsoleColor errorColor = Red)
        {
            int tries = TRIES;
            do
            {
                WriteColorLine(prompt, promptColor);
                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount >= 0)
                {
                    return amount;
                }

                WriteColorLine(formatErrorMessage + $" Price of the product should be positive. {--tries} tries left.", errorColor);
            }
            while (tries > 0);

            return 0m;
        }

        /// <summary>
        /// Prompts the user via the console to enter a product ID and validates the input.
        /// </summary>
        /// <param name="prompt">The text message displayed to request ID input from the user.</param>
        /// <param name="formatErrorMessage">The error message displayed when the user enters an invalid ID.</param>
        /// <param name="promptColor">The color used for prompt foreground.</param>
        /// <param name="errorColor">The color used for error message foreground.</param>
        /// <returns>The valid <see cref="string"/> product ID entered by the user.</returns>
        /// <remarks>
        /// This method repeats the prompt indefinitely until the user inputs a valid product ID string.
        /// </remarks>
        public static string? GetProductID(
            string prompt,
            string formatErrorMessage,
            ConsoleColor promptColor = Blue,
            ConsoleColor errorColor = Red)
        {
            string? id;
            int tries = TRIES;
            do
            {
                WriteColorLine(prompt, promptColor);
                id = Console.ReadLine();
                if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id) || !IsValidId(id))
                {
                    WriteColorLine(formatErrorMessage + $"{--tries} tries left.", errorColor);
                    continue;
                }

                return id.ToUpper();
            }
            while (tries > 0);

            return null;
        }

        /// <summary>
        /// Prompts the user via the console to enter a product name and validates the input.
        /// </summary>
        /// <param name="prompt">The text message displayed to request name input from the user.</param>
        /// <param name="formatErrorMessage">The error message displayed when the user enters an invalid string.</param>
        /// <param name="promptColor">The color used for prompt foreground.</param>
        /// <param name="errorColor">The color used for error message foreground.</param>
        /// <returns>The valid <see cref="string"/> product name entered by the user.</returns>
        /// <remarks>
        /// This method repeats the prompt indefinitely until the user inputs a valid product name string.
        /// </remarks>
        public static string GetProductName(
            string prompt,
            string formatErrorMessage,
            ConsoleColor promptColor = Blue,
            ConsoleColor errorColor = Red)
        {
            string? name;
            int tries = TRIES;
            do
            {
                WriteColorLine(prompt, promptColor);
                name = Console.ReadLine();
                if (name is null || !IsValidName(name))
                {
                    WriteColorLine($"Name is invalid, try again. {--tries} tries left.", errorColor);
                    continue;
                }

                return name;
            }
            while (tries > 0);

            return string.Empty;
        }

        /// <summary>
        /// Prompts the user via the console to enter a product quantity and validates the input.
        /// </summary>
        /// <param name="prompt">The text message displayed to request quantity input from the user.</param>
        /// <param name="formatErrorMessage">The text message displayed when the input is invalid.</param>
        /// <param name="promptColor">The color used for prompt foreground.</param>
        /// <param name="errorColor">The color used for error message foreground.</param>
        /// <returns>The valid <see cref="int"/> quantity value entered by the user.</returns>
        /// <remarks>
        /// This method repeats the prompt indefinitely until the user inputs a valid quantity is provided.
        /// </remarks>
        public static int GetQuantity(
            string prompt,
            string formatErrorMessage,
            ConsoleColor promptColor = Blue,
            ConsoleColor errorColor = Red)
        {
            int tries = TRIES;
            do
            {
                WriteColorLine(prompt, promptColor);
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    return quantity;
                }

                WriteColorLine(
                    $@"{formatErrorMessage} Quantity of the product should be natural number.
{--tries} tries left.",
                    errorColor);
            }
            while (tries > 0);

            return 0;
        }

        /// <summary>
        /// Generates a stylized, rounded console table displaying a list of products.
        /// </summary>
        /// <param name="products">The list of <see cref="Product"/> items to include in the table.</param>
        /// <returns>A configured <see cref="Table"/> instance ready to be rendered to the console.</returns>
        /// <remarks>
        /// The table features blue rounded borders, an 'Inventory Listings' title,
        /// and formatted columns for Product ID, Name, Price, and Quantity.
        /// </remarks>
        public static Table PrepareTable(List<Product> products)
        {
            // Initialize a stylized table
            var table = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Color.Blue)
                .Title("[yellow bold]Inventory Listings[/]\n");

            // Define column layouts and headers
            table.AddColumn(new TableColumn("[cyan bold]Product ID[/]").Centered());
            table.AddColumn(new TableColumn("[green bold]Product Name[/]"));
            table.AddColumn(new TableColumn("[magenta bold]Price[/]").RightAligned());
            table.AddColumn(new TableColumn("[yellow bold]Quantity[/]").Centered());

            foreach (Product product in products)
            {
                table.AddRow(
                    product.Id,
                    product.Name,
                    "$" + product.Price.ToString(),
                    product.Quantity.ToString());
            }

            return table;
        }

        /// <summary>
        /// Pauses execution and clears the console screen.
        /// </summary>
        /// <param name="ms">The pause duration in milliseconds. Defaults to 1000 ms.</param>
        /// <remarks>
        /// This method blocks the calling thread using <see cref="Thread.Sleep(int)"/>.
        /// </remarks>
        public static void UICleanup(int ms = 1000)
        {
            Thread.Sleep(ms);
            Console.Clear();
        }

        /// <summary>
        /// Writes a message to the console in a specified color and resets the color afterward.
        /// </summary>
        /// <param name="message">The text message to write.</param>
        /// <param name="color">The color of the text.</param>
        public static void WriteColorLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
