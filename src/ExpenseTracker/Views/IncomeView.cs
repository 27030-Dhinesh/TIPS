using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Spectre.Console;
using static ExpenseTracker.Helpers.ConsoleHelper;

namespace ExpenseTracker.Views
{
    /// <summary>
    /// Provides the user interface for viewing and managing income records.
    /// </summary>
    public class IncomeView
    {
        private readonly IncomeService _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeView"/> class.
        /// </summary>
        /// <param name="manager">
        /// The finance service used to manage and retrieve financial data.
        /// </param>
        public IncomeView(IncomeService manager)
        {
            this._manager = manager;
        }

        /// <summary>
        /// Displays the available menu options for Income to the console.
        /// </summary>
        public void DisplayMenu()
        {
            foreach (MenuOption option in Enum.GetValues<MenuOption>())
            {
                Console.WriteLine($"{(int)option}. {option}");
            }
        }

        /// <summary>
        /// Prompts the user for income details and creates a new income entry.
        /// </summary>
        public void AddIncome()
        {
            Guid id = Guid.NewGuid();
            decimal amount = GetAmount("Enter Income amount:", "Invalid input for Income.");
            if (amount == decimal.Zero)
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.DarkYellow);
                return;
            }

            DateOnly date = GetDate("Enter Date of Transaction (d-M-yy):", "Invalid input for Date.");
            if (date.Equals(DateOnly.MinValue))
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.DarkYellow);
                return;
            }

            // Try to match the result to a non-null IncomeCategory.
            // If it fails (null or wrong type), enter the `if` block.
            // If it succeeds, assign the value to the new variable `category`
            // (non-nullable) and skip the `if` block.
            if (GetIncomeCategory() is not IncomeCategory category)
            {
                WriteColorLine("Invalid Category...Switching to main menu...", ConsoleColor.DarkYellow);
                return;
            }

            Income income = new Income(id, amount, date, category.ToString());

            if (this._manager.AddIncome(income))
            {
                WriteColorLine("Income entry added successfully", ConsoleColor.DarkGreen);
            }
            else
            {
                WriteColorLine("Failed to add income entry", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Displays all income transaction entries in a formatted table.
        /// </summary>
        public void ViewIncome()
        {
            if (this._manager.IsIncomesEmpty())
            {
                WriteColorLine("There are no income transaction entries.", ConsoleColor.Red);
                return;
            }

            List<Income> incomeEntries = this._manager.GetIncomes();

            Table table = PrepareIncomeTable(incomeEntries);

            AnsiConsole.Write(table);
        }

        public void ViewIncomesByCategory()
        {
            if (this._manager.IsIncomesEmpty())
            {
                WriteColorLine("There are no income transaction entries.", ConsoleColor.Red);
                return;
            }

            if (GetIncomeCategory() is not IncomeCategory category)
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.DarkYellow);
                return;
            }

            List<Income> filteredEntries = this._manager.GetIncomesByCategory(category);

            if (filteredEntries.Count == 0)
            {
                WriteColorLine($"There are no income transaction entries for category {category}.", ConsoleColor.Red);
                return;
            }

            Table table = PrepareIncomeTable(filteredEntries);

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Prompts the user for updated income details to update existing income entry.
        /// </summary>
        public void EditIncome()
        {
            if (this._manager.IsIncomesEmpty())
            {
                WriteColorLine("There are no income transaction entries.", ConsoleColor.Red);
                return;
            }

            this.ViewIncome();

            int count = this._manager.GetIncomeEntriesCount();

            int position = GetIntInRange(1, count, "Enter the ID to edit:");
            if (position == int.MinValue)
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.Yellow);
                return;
            }

            decimal amount = GetAmount("Enter new amount:", "Invalid input for amount.");
            if (amount == decimal.Zero)
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.Yellow);
                return;
            }

            DateOnly date = GetDate("Enter new date (d-M-yy):", "Invalid input for date.");
            if (date.Equals(DateOnly.MinValue))
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.Yellow);
                return;
            }

            if (GetIncomeCategory() is not IncomeCategory category)
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.Yellow);
                return;
            }

            Income updatedEntry = new Income(
                Guid.NewGuid(),
                amount,
                date,
                category.ToString());

            if (this._manager.EditIncome(position - 1, updatedEntry))
            {
                WriteColorLine("Income entry updated successfully.", ConsoleColor.Green);
                return;
            }

            WriteColorLine("Failed to updated income entry", ConsoleColor.Red);
        }

        /// <summary>
        /// Deletes the income entry from the repository.
        /// </summary>
        public void DeleteIncome()
        {
            if (this._manager.IsIncomesEmpty())
            {
                WriteColorLine("There are no income transaction entries.", ConsoleColor.Red);
                return;
            }

            this.ViewIncome();

            int count = this._manager.GetIncomeEntriesCount();

            int position = GetIntInRange(1, count, "Enter the ID to delete:");
            if (position == int.MinValue)
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.Yellow);
                return;
            }

            if (this._manager.DeleteIncome(position))
            {
                WriteColorLine("Income entry deleted successfully.", ConsoleColor.Green);
                return;
            }

            WriteColorLine("Failed to delete income entry", ConsoleColor.Red);
        }
    }
}
