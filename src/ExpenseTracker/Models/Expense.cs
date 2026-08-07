namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents an expense and contains the data associated with an expense record.
    /// </summary>
    internal class Expense
    {
        public Expense(Guid id, decimal amount, DateTime date, ExpenseCategory category)
        {
            this.Id = id;
            this.Amount = amount;
            this.Date = date;
            this.Category = category;
        }

        public Expense(Expense other)
        {
            this.Id = other.Id;
            this.Amount = other.Amount;
            this.Date = other.Date;
            this.Category = other.Category;
        }

        public static bool operator true(Expense expense) => expense is not null;

        public static bool operator false(Expense expense) => expense is null;

        /// <summary>
        /// Gets or sets the unique identifier for the expense record.
        /// </summary>
        /// <value>
        /// A Guid representing the unique expense identifier.
        /// </value>
        internal Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the monetary amount of the expense.
        /// </summary>
        /// <value>
        /// The expense amount.
        /// </value>
        internal decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date on which the expense was incurred.
        /// </summary>
        /// <value>
        /// The date associated with the expense transaction.
        /// </value>
        internal DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the category that classifies the expense.
        /// </summary>
        /// <value>
        /// An <see cref="ExpenseCategory"/> value representing the expense type.
        /// </value>
        internal ExpenseCategory Category { get; set; }

        public Expense Clone()
        {
            return new Expense(this);
        }
    }
}
