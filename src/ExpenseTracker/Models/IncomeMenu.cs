namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the available menu options for managing income entries.
    /// </summary>
    public enum IncomeMenu
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

        ViewByCategory,

        /// <summary>
        /// Switch back to the main menu.
        /// </summary>
        SwitchToMainMenu,
    }
}
