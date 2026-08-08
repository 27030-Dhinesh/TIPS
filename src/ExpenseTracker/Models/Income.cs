namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents an income record and contains the data associated with
    /// a source of income.
    /// </summary>
    public class Income
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class with the specified details.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the income record.
        /// </param>
        /// <param name="amount">
        /// The monetary amount of the income.
        /// </param>
        /// <param name="date">
        /// The date and time when the income was received.
        /// </param>
        /// <param name="category">
        /// The category associated with the income.
        /// </param>
        public Income(Guid id, decimal amount, DateOnly date, IncomeCategory category)
        {
            this.Id = id;
            this.Amount = amount;
            this.Date = date;
            this.Category = category;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class by copying
        /// the values from an existing <see cref="Income"/> instance.
        /// </summary>
        /// <param name="other">
        /// The <see cref="Income"/> instance whose values are copied to the new instance.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        public Income(Income other)
        {
            ArgumentNullException.ThrowIfNull(other);

            this.Id = other.Id;
            this.Amount = other.Amount;
            this.Date = other.Date;
            this.Category = other.Category;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the expense.
        /// </summary>
        /// <value>
        /// A <see cref="Guid"/> that uniquely identifies the expense.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the monetary amount of the expense.
        /// </summary>
        /// <value>
        /// The amount associated with the expense.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date on which the expense was incurred.
        /// </summary>
        /// <value>
        /// The date of the expense.
        /// </value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the category that classifies the income.
        /// </summary>
        /// <value>
        /// An <see cref="IncomeCategory"/> value representing the income type.
        /// </value>
        public IncomeCategory Category { get; set; }

        public static bool operator true(Income income) => income is not null;

        public static bool operator false(Income income) => income is null;

        /// <summary>
        /// Creates a copy of the current <see cref="Income"/> instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="Income"/> object initialized with the values of the current instance.
        /// </returns>
        public Income Clone()
        {
            return new Income(this);
        }
    }
}
