using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Spectre.Console;
using static ExpenseTracker.Helpers.ConsoleHelper;

namespace ExpenseTracker.Views
{
    /// <summary>
    /// Manages console-based interactions for financial management operations.
    /// </summary>
    /// <remarks>
    /// Handles all user-facing console operations, such as displaying income and
    /// expense information, presenting menus, prompting for input, and showing
    /// validation or status messages. This class is responsible for presentation
    /// concerns only and delegates business operations to the service layer.
    /// </remarks>
    public class FinanceView
    {
        private readonly FinanceService _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceView"/> class.
        /// </summary>
        /// <param name="manager">
        /// The finance service used to manage and retrieve financial data.
        /// </param>
        public FinanceView(FinanceService manager)
        {
            this._manager = manager;
        }

        /// <summary>
        /// Displays the available menu options to the console.
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
            if (GetIncomeCategory() is not IncomeCategory category)
            {
                WriteColorLine("Invalid Category...Switching to main menu...", ConsoleColor.DarkYellow);
                return;
            }

            Income income = new Income(id, amount, date, category);

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

            Expense expense = new Expense(id, amount, date, category);

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

            DateOnly date = GetDate("Enter new date:", "Invalid input for date.");
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
                category);

            if (this._manager.EditIncome(position - 1, updatedEntry))
            {
                WriteColorLine("Income entry updated successfully.", ConsoleColor.Green);
                return;
            }

            WriteColorLine("Failed to updated income entry", ConsoleColor.Red);
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
                category);

            if (this._manager.EditExpense(position - 1, updatedEntry))
            {
                WriteColorLine("Expense entry updated successfully.", ConsoleColor.Green);
                return;
            }

            WriteColorLine("Failed to updated expense entry", ConsoleColor.Red);
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

        /// <summary>
        /// Display net balance summary based on income and expense entries.
        /// </summary>
        public void ShowSummary()
        {
            List<Income> incomes = this._manager.GetIncomes();
            List<Expense> expenses = this._manager.GetExpenses();

            decimal totalIncome = incomes.Sum(entry => entry.Amount);
            decimal totalExpense = expenses.Sum(entry => entry.Amount);

            WriteColorLine(
                @$"Total Income: {totalIncome}
Total Expense: {totalExpense}

Net Balance: {totalIncome - totalExpense}",
                ConsoleColor.DarkYellow);
        }
    }
}
