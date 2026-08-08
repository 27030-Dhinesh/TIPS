using ExpenseTracker.Models;
using Spectre.Console;
using static System.ConsoleColor;

namespace ExpenseTracker.Helpers
{
    /// <summary>
    /// Provides utility methods for interacting with the console, including
    /// formatted output, user input handling, and console-related operations.
    /// </summary>
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
            ConsoleColor promptColor = Blue,
            ConsoleColor errorColor = Red)
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

        /// <summary>
        /// Prompts the user to enter a positive monetary amount and validates the input.
        /// </summary>
        /// <param name="prompt">
        /// The message displayed to the user requesting an amount.
        /// </param>
        /// <param name="errorMessage">
        /// The error message displayed when the entered value is invalid.
        /// </param>
        /// <param name="promptColor">
        /// The color used to display the prompt message. Defaults to <see cref="ConsoleColor.Blue"/>.
        /// </param>
        /// <param name="errorColor">
        /// The color used to display validation error messages. Defaults to <see cref="ConsoleColor.Red"/>.
        /// </param>
        /// <returns>
        /// The validated positive decimal amount entered by the user.
        /// Returns <see cref="decimal.Zero"/> if the user fails to provide a valid amount
        /// within the configured number of attempts.
        /// </returns>
        public static decimal GetAmount(
            string prompt,
            string errorMessage,
            ConsoleColor promptColor = Blue,
            ConsoleColor errorColor = Red)
        {
            for (int i = TRIES; i > 0;)
            {
                WriteColorLine(prompt, promptColor);
                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                {
                    return amount;
                }

                WriteColorLine($"{errorMessage} {--i} tries left.", errorColor);
            }

            return decimal.Zero;
        }

        /// <summary>
        /// Displays the available <see cref="IncomeCategory"/> options and prompts the user
        /// to select a category.
        /// </summary>
        /// <param name="prompt">
        /// The message displayed to the user when requesting a category selection.
        /// </param>
        /// <param name="promptColor">
        /// The color used to display the prompt message. Defaults to
        /// <see cref="ConsoleColor.Blue"/>.
        /// </param>
        /// <returns>
        /// The selected <see cref="IncomeCategory"/> value if a valid selection is made;
        /// otherwise, <see langword="null"/> when the selection process is canceled or
        /// no valid choice is obtained.
        /// </returns>
        public static IncomeCategory? GetIncomeCategory(
            string prompt,
            ConsoleColor promptColor = Blue)
        {
            foreach (IncomeCategory category in Enum.GetValues<IncomeCategory>())
            {
                Console.WriteLine($"{(int)category}. {category}");
            }

            int choice = GetIntInRange(
                min: 1,
                max: Enum.GetValues<IncomeCategory>().Length,
                prompt: "Enter your choice:");

            if (choice == int.MinValue)
            {
                return null;
            }

            return (IncomeCategory)choice;
        }

        /// <summary>
        /// Displays the available <see cref="ExpenseCategory"/> options and prompts the user
        /// to select a category.
        /// </summary>
        /// <param name="prompt">
        /// The message displayed to the user when requesting a category selection.
        /// </param>
        /// <param name="promptColor">
        /// The color used to display the prompt message. Defaults to
        /// <see cref="ConsoleColor.Blue"/>.
        /// </param>
        /// <returns>
        /// The selected <see cref="ExpenseCategory"/> value if a valid selection is made;
        /// otherwise, <see langword="null"/> when the selection process is canceled or
        /// no valid choice is obtained.
        /// </returns>
        public static ExpenseCategory? GetExpenseCategory(
            string prompt,
            ConsoleColor promptColor = Blue)
        {
            foreach (ExpenseCategory category in Enum.GetValues<ExpenseCategory>())
            {
                Console.WriteLine($"{(int)category}. {category}");
            }

            int choice = GetIntInRange(
                min: 1,
                max: Enum.GetValues<ExpenseCategory>().Length,
                prompt: "Enter your choice:");

            if (choice == int.MinValue)
            {
                return null;
            }

            return (ExpenseCategory)choice;
        }

        /// <summary>
        /// Creates and populates a formatted table containing the specified income entries.
        /// </summary>
        /// <param name="entries">
        /// The collection of income entries to display in the table.
        /// </param>
        /// <returns>
        /// A <see cref="Table"/> containing the income entry details, including
        /// the entry identifier, amount, date, and category.
        /// </returns>
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
            for (int i = 1; i <= entries.Count; ++i)
            {
                entry = entries[i - 1];
                table.AddRow(
                    i.ToString(),
                    "$" + entry.Amount.ToString(),
                    entry.Date.ToString("d"),
                    entry.Category.ToString());
            }

            return table;
        }

        /// <summary>
        /// Creates and populates a formatted table containing the specified expense entries.
        /// </summary>
        /// <param name="entries">
        /// The collection of expense entries to display in the table.
        /// </param>
        /// <returns>
        /// A <see cref="Table"/> containing the expense entry details, including
        /// the entry identifier, amount, date, and category.
        /// </returns>
        public static Table PrepareExpenseTable(List<Expense> entries)
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

            Expense entry;
            for (int i = 1; i <= entries.Count; ++i)
            {
                entry = entries[i - 1];
                table.AddRow(
                    i.ToString(),
                    "$" + entry.Amount.ToString(),
                    entry.Date.ToString("d"),
                    entry.Category.ToString());
            }

            return table;
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

        /// <summary>
        /// Prompts the user to enter an integer within the specified range and validates the input.
        /// </summary>
        /// <param name="min">
        /// The minimum valid value, inclusive.
        /// </param>
        /// <param name="max">
        /// The maximum valid value, inclusive.
        /// </param>
        /// <param name="prompt">
        /// The message displayed to request input from the user.
        /// </param>
        /// <param name="promptColor">
        /// The color used to display the prompt message. Defaults to
        /// <see cref="ConsoleColor.Blue"/>.
        /// </param>
        /// <returns>
        /// The validated integer entered by the user if it falls within the specified range;
        /// otherwise, <see cref="int.MinValue"/> if the maximum number of allowed attempts
        /// is exceeded.
        /// </returns>
        public static int GetIntInRange(
            int min,
            int max,
            string prompt,
            ConsoleColor promptColor = ConsoleColor.Blue)
        {
            for (int i = TRIES; i > 0;)
            {
                WriteColorLine(prompt, promptColor);
                if (
                    int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result >= min && result <= max)
                    {
                        return result;
                    }

                    WriteColorLine(
                        $"Input must be in range {min} and {max}. {--i} tries left.",
                        ConsoleColor.Red);
                }
                else
                {
                    WriteColorLine(
                        $"Please enter a valid integer within range. {--i} tries left.",
                        ConsoleColor.Red);
                }
            }

            return int.MinValue;
        }
    }
}
