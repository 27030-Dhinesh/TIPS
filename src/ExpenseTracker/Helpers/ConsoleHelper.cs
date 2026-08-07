using ExpenseTracker.Models;
using Spectre.Console;
using static System.ConsoleColor;

namespace ExpenseTracker.Helpers
{
    internal static class ConsoleHelper
    {
        private const int TRIES = 3;

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

                WriteColorLine(
                    $@"{formatErrorMessage} Price of the product should be positive.
{--tries} tries left.", errorColor);
            }
            while (tries > 0);

            return 0m;
        }
    }
}
