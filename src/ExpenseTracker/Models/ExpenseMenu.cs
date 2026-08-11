namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the available menu options for managing expense entries.
    /// </summary>
    public enum ExpenseMenu
    {
        /// <summary>
        /// Adds a new expense record.
        /// </summary>
        AddExpense = 1,

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
        /// Switch back to the main menu.
        /// </summary>
        SwitchToMainMenu,
    }
}
