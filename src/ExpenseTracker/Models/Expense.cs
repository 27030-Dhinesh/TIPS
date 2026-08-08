namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents an expense and contains the data associated with an expense record.
    /// </summary>
    public class Expense
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class with the specified details.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the expense.
        /// </param>
        /// <param name="amount">
        /// The monetary amount of the expense.
        /// </param>
        /// <param name="date">
        /// The date on which the expense was incurred.
        /// </param>
        /// <param name="category">
        /// The category associated with the expense.
        /// </param>
        public Expense(Guid id, decimal amount, DateOnly date, ExpenseCategory category)
        {
            this.Id = id;
            this.Amount = amount;
            this.Date = date;
            this.Category = category;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class by copying
        /// the values from an existing <see cref="Expense"/> instance.
        /// </summary>
        /// <param name="other">
        /// The <see cref="Expense"/> instance whose values are copied to the new instance.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        public Expense(Expense other)
        {
            ArgumentNullException.ThrowIfNull(other);

            this.Id = other.Id;
            this.Amount = other.Amount;
            this.Date = other.Date;
            this.Category = other.Category;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the expense record.
        /// </summary>
        /// <value>
        /// A Guid representing the unique expense identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the monetary amount of the expense.
        /// </summary>
        /// <value>
        /// The expense amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date on which the expense was incurred.
        /// </summary>
        /// <value>
        /// The date associated with the expense transaction.
        /// </value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the category that classifies the expense.
        /// </summary>
        /// <value>
        /// An <see cref="ExpenseCategory"/> value representing the expense type.
        /// </value>
        public ExpenseCategory Category { get; set; }

        public static bool operator true(Expense expense) => expense is not null;

        public static bool operator false(Expense expense) => expense is null;

        /// <summary>
        /// Creates a copy of the current <see cref="Expense"/> instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="Expense"/> object initialized with the values of the current instance.
        /// </returns>
        public Expense Clone()
        {
            return new Expense(this);
        }
    }
}
