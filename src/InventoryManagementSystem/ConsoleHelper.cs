using System.Text;
using InventoryManagementSystem.Models;
using Spectre.Console;
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
        /// <remarks>
        /// This method repeats the prompt indefinitely until the user inputs a valid string.
        /// </remarks>
        public static string GetInput(string prompt, string errorMessage)
        {
            string? input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(errorMessage);
                    continue;
                }

                return input;
            }
            while (true);
        }

        /// <summary>
        /// Prompts the user via the console to enter a price and validates the input.
        /// </summary>
        /// <param name="prompt">The text message displayed to request price input from the user.</param>
        /// <param name="formatErrorMessage">The text message displayed when the input cannot be parsed as a positive decimal.</param>
        /// <returns>The valid <see cref="decimal"/> price value entered by the user.</returns>
        /// <remarks>
        /// This method repeats the prompt indefinitely until the user inputs a valid decimal formatting string.
        /// </remarks>
        public static decimal GetPrice(string prompt, string formatErrorMessage)
        {
            do
            {
                Console.WriteLine(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount >= 0)
                {
                    return amount;
                }

                Console.WriteLine(formatErrorMessage + " Price of the product should be positive.");
            }
            while (true);
        }

        /// <summary>
        /// Prompts the user via the console to enter a product ID and validates the input.
        /// </summary>
        /// <param name="prompt">The text message displayed to request ID input from the user.</param>
        /// <param name="formatErrorMessage">The error message displayed when the user enters an invalid ID.</param>
        /// <returns>The valid <see cref="string"/> product ID entered by the user.</returns>
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

                return id.ToUpper();
            }
            while (true);
        }

        /// <summary>
        /// Prompts the user via the console to enter a product name and validates the input.
        /// </summary>
        /// <param name="prompt">The text message displayed to request name input from the user.</param>
        /// <param name="formatErrorMessage">The error message displayed when the user enters an invalid string.</param>
        /// <returns>The valid <see cref="string"/> product name entered by the user.</returns>
        /// <remarks>
        /// This method repeats the prompt indefinitely until the user inputs a valid product name string.
        /// </remarks>
        public static string GetProductName(string prompt, string formatErrorMessage)
        {
            string name;
            do
            {
                name = GetInput(prompt, formatErrorMessage);

                if (!IsValidName(name))
                {
                    Console.WriteLine("Name is invalid, try again.");
                }

                return name;
            }
            while (true);
        }

        /// <summary>
        /// Prompts the user via the console to enter a product quantity and validates the input.
        /// </summary>
        /// <param name="prompt">The text message displayed to request quantity input from the user.</param>
        /// <param name="formatErrorMessage">The text message displayed when the input is invalid.</param>
        /// <returns>The valid <see cref="int"/> quantity value entered by the user.</returns>
        /// <remarks>
        /// This method repeats the prompt indefinitely until the user inputs a valid quantity is provided.
        /// </remarks>
        public static int GetQuantity(string prompt, string formatErrorMessage)
        {
            do
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    return quantity;
                }

                Console.WriteLine(formatErrorMessage + " Quantity of the product should be natural number.");
            }
            while (true);
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
            Encoding originalEncoding = Console.OutputEncoding;
            Console.OutputEncoding = Encoding.UTF8;

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
                    product.Price.ToString("C"),
                    product.Quantity.ToString());
            }

            Console.OutputEncoding = originalEncoding;
            return table;
        }
    }
}
