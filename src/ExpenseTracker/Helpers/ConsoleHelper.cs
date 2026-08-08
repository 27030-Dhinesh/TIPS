using System.Globalization;
using System.Threading.Tasks;
using ExpenseTracker.Models;
using Spectre.Console;
using static System.ConsoleColor;

namespace ExpenseTracker.Helpers
{
    internal static class ConsoleHelper
    {
        private const int TRIES = 3;

        /// <summary>
        /// Prompts the user to enter a valid date and continues retrying until a valid
        /// <see cref="DateOnly"/> value is provided or the maximum number of attempts is reached.
        /// </summary>
        /// <param name="prompt">
        /// The message displayed to the user when requesting a date input.
        /// </param>
        /// <param name="errorMessage">
        /// The message displayed when the entered value cannot be parsed as a valid date.
        /// </param>
        /// <param name="promptColor">
        /// The console text color used when displaying the prompt message.
        /// </param>
        /// <param name="errorColor">
        /// The console text color used when displaying validation error messages.
        /// </param>
        /// <returns>
        /// A <see cref="DateOnly"/> representing the valid date entered by the user.
        /// Returns <see cref="DateOnly.MinValue"/> if the maximum number of attempts is exhausted.
        /// </returns>
        public static DateOnly GetDate(
            string prompt,
            string errorMessage,
            ConsoleColor promptColor,
            ConsoleColor errorColor)
        {
            for (int i = TRIES; i > 0;)
            {
                WriteColorLine(prompt, promptColor);
                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly date))
                {
                    return date;
                }
                else
                {
                    WriteColorLine($"{errorMessage} {--i} tries left.", errorColor);
                }
            }

            return DateOnly.MinValue;
        }

        public static Table PrepareIncomeTable(List<Income> entries)
        {
            // Initialize a stylized table
            var table = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Color.Blue)
                .Title("[yellow bold]Transaction Entries[/]\n");

            // Define column layouts and headers
            table.AddColumn(new TableColumn("[cyan bold]ID[/]").Centered());
            table.AddColumn(new TableColumn("[magenta bold]Amount[/]").RightAligned());
            table.AddColumn(new TableColumn("[green bold]Date[/]"));
            table.AddColumn(new TableColumn("[yellow bold]Category[/]").Centered());

            Income entry;
            for (int i = 0; i < entries.Count; ++i)
            {
                entry = entries[i];
                table.AddRow(
                    i.ToString(),
                    "$" + entry.Amount.ToString(),
                    entry.Date.ToString("d"),
                    entry.Category.ToString());
            }

            return table;
        }

        public static decimal GetAmount(
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

                WriteColorLine(
                    $@"{formatErrorMessage} Price of the product should be positive.
{--tries} tries left.", errorColor);
            }
            while (tries > 0);

            return 0m;
        }

        /// <summary>
        /// Writes a message to the console in a specified color and resets the color afterward.
        /// </summary>
        /// <param name="prompt">The text message to write.</param>
        /// <param name="promptColor">The color of the text.</param>
        public static void WriteColorLine(string prompt, ConsoleColor promptColor)
        {
            Console.ForegroundColor = promptColor;
            Console.WriteLine(prompt);
            Console.ResetColor();
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
    }
}
