using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Spectre.Console;
using static ExpenseTracker.Helpers.ConsoleHelper;

namespace ExpenseTracker.Views
{
    internal class ExpenseView
    {
        private readonly ExpenseService _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseView"/> class.
        /// </summary>
        /// <param name="manager">
        /// The finance service used to manage and retrieve financial data.
        /// </param>
        public ExpenseView(ExpenseService manager)
        {
            this._manager = manager;
        }

        /// <summary>
        /// Prompts the user for expense details and creates a new expense entry.
        /// </summary>
        public void AddExpense()
        {
            Guid id = Guid.NewGuid();
            decimal amount = GetAmount("Enter Expense amount:", "Invalid input for Expense.");
            if (amount == decimal.Zero)
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.DarkYellow);
                return;
            }

            DateOnly date = GetDate("Enter Date of Transaction (dd/mm/yyyy):", "Invalid input for Date.");
            if (date.Equals(DateOnly.MinValue))
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.DarkYellow);
                return;
            }

            // Try to match the result to a non-null IncomeCategory.
            // If it fails (null or wrong type), enter the `if` block.
            // If it succeeds, assign the value to the new variable `category`
            // (non-nullable) and skip the `if` block.
            if (GetExpenseCategory() is not ExpenseCategory category)
            {
                WriteColorLine("Invalid Category...Switching to main menu...", ConsoleColor.DarkYellow);
                return;
            }

            Expense expense = new Expense(id, amount, date, category.ToString());

            if (this._manager.AddExpense(expense))
            {
                WriteColorLine("Expense entry added successfully", ConsoleColor.DarkGreen);
            }
            else
            {
                WriteColorLine("Failed to add expense entry", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Displays all expense transaction entries in a formatted table.
        /// </summary>
        public void ViewExpense()
        {
            if (this._manager.IsExpensesEmpty())
            {
                WriteColorLine("There are no expense transaction entries.", ConsoleColor.Red);
                return;
            }

            List<Expense> expenseEntries = this._manager.GetExpenses();

            Table table = PrepareExpenseTable(expenseEntries);

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// Prompts the user for updated expense details to update existing expense entry.
        /// </summary>
        public void EditExpense()
        {
            if (this._manager.IsExpensesEmpty())
            {
                WriteColorLine("There are no expense transaction entries.", ConsoleColor.Red);
                return;
            }

            this.ViewExpense();

            int count = this._manager.GetExpenseEntriesCount();

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

            DateOnly date = GetDate("Enter new date:", "Invalid input for date.");
            if (date.Equals(DateOnly.MinValue))
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.Yellow);
                return;
            }

            if (GetExpenseCategory() is not ExpenseCategory category)
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.Yellow);
                return;
            }

            Expense updatedEntry = new Expense(
                Guid.NewGuid(),
                amount,
                date,
                category.ToString());

            if (this._manager.EditExpense(position - 1, updatedEntry))
            {
                WriteColorLine("Expense entry updated successfully.", ConsoleColor.Green);
                return;
            }

            WriteColorLine("Failed to updated expense entry", ConsoleColor.Red);
        }

        /// <summary>
        /// Deletes the expense entry from the repository.
        /// </summary>
        public void DeleteExpense()
        {
            if (this._manager.IsExpensesEmpty())
            {
                WriteColorLine("There are no expense transaction entries.", ConsoleColor.Red);
                return;
            }

            this.ViewExpense();

            int count = this._manager.GetExpenseEntriesCount();

            int position = GetIntInRange(1, count, "Enter the ID to delete:");
            if (position == int.MinValue)
            {
                WriteColorLine("Switching to main menu...", ConsoleColor.Yellow);
                return;
            }

            if (this._manager.DeleteExpense(position))
            {
                WriteColorLine("Expense entry deleted successfully.", ConsoleColor.Green);
                return;
            }

            WriteColorLine("Failed to delete expense entry", ConsoleColor.Red);
        }
    }
}
