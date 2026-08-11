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
    public enum MenuOption
    {
        /// <summary>
        /// Manage income-related operations.
        /// </summary>
        IncomeManagement = 1,

        /// <summary>
        /// Manage expense-related operations.
        /// </summary>
        ExpenseManagement,

        /// <summary>
        /// Display a consolidated summary of income and expense information.
        /// </summary>
        ShowSummary,

        /// <summary>
        /// Exit the application.
        /// </summary>
        Exit,
    }
}
