namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the available menu options in the application.
    /// </summary>
    /// <remarks>
    /// Used to identify and execute user-selected actions from the
    /// application's main menu.
    /// Explicit numeric values are assigned to align menu selections
    /// with user input.
    /// </remarks>
    internal enum MenuOption
    {
        /// <summary>
        /// Adds a new income record.
        /// </summary>
        AddIncome = 1,

        /// <summary>
        /// Displays existing income records.
        /// </summary>
        ViewIncome,

        /// <summary>
        /// Modifies an existing income record.
        /// </summary>
        EditIncome,

        /// <summary>
        /// Removes an existing income record.
        /// </summary>
        DeleteIncome,

        /// <summary>
        /// Adds a new expense record.
        /// </summary>
        AddExpense,

        /// <summary>
        /// Displays existing expense records.
        /// </summary>
        ViewExpense,

        /// <summary>
        /// Modifies an existing expense record.
        /// </summary>
        EditExpense,

        /// <summary>
        /// Removes an existing expense record.
        /// </summary>
        DeleteExpense,

        /// <summary>
        /// Displays a summary of income and expense data.
        /// </summary>
        ShowSummary,
    }
}
