namespace ExpenseTracker.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEntry
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction record.
        /// </summary>
        /// <value>
        /// A Guid representing the unique expense identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the monetary amount of the transaction record.
        /// </summary>
        /// <value>
        /// The expense amount.
        /// </value>
        decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date on which the transaction occured.
        /// </summary>
        /// <value>
        /// The date associated with the expense transaction.
        /// </value>
        DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the category that classifies the expense.
        /// </summary>
        /// <value>
        /// A string value representing the expense type.
        /// </value>
        string Category { get; set; }

        IEntry Clone();
    }
}
