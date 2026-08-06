namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents an income record and contains the data associated with
    /// a source of income.
    /// </summary>
    internal class Income : Entry
    {
        /// <summary>
        /// Gets or sets the category that classifies the income.
        /// </summary>
        /// <value>
        /// An <see cref="IncomeCategory"/> value representing the income type.
        /// </value>
        internal IncomeCategory Category { get; set; }
    }
}
