namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents an income record and contains the data associated with
    /// a source of income.
    /// </summary>
    internal class Income
    {
        public Income(Guid id, decimal amount, DateTime date, IncomeCategory category)
        {
            this.Id = id;
            this.Amount = amount;
            this.Date = date;
            this.Category = category;
        }

        public Income(Income other)
        {
            this.Id = other.Id;
            this.Amount = other.Amount;
            this.Date = other.Date;
            this.Category = other.Category;
        }

        public static bool operator true(Income income) => income is not null;

        public static bool operator false(Income income) => income is null;

        internal Guid Id { get; set; }

        internal decimal Amount { get; set; }

        internal DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the category that classifies the income.
        /// </summary>
        /// <value>
        /// An <see cref="IncomeCategory"/> value representing the income type.
        /// </value>
        internal IncomeCategory Category { get; set; }

        public Income Clone()
        {
            return new Income(this);
        }
    }
}
