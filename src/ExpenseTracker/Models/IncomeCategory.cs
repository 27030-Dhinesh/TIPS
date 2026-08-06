namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the category to which an income source belongs.
    /// </summary>
    /// <remarks>
    /// Used to classify income transactions for reporting, analysis, and
    /// financial tracking purposes.</remarks>
    internal enum IncomeCategory
    {
        /// <summary>
        /// Income earned through regular employment or wages.
        /// </summary>
        Salary,

        /// <summary>
        /// Income earned from freelance, contract, or independent professional
        /// work.
        /// </summary>
        Freelancing,

        /// <summary>
        /// Additional compensation received beyond regular salary, such as
        /// performance or annual bonuses.
        /// </summary>
        Bonus,

        /// <summary>
        /// Income earned from interest-bearing financial accounts or investments.
        /// </summary>
        Interest,

        /// <summary>
        /// Income generated from renting or leasing properties or assets.
        /// </summary>
        Rental,

        /// <summary>
        /// Income that does not fit into any predefined category.
        /// </summary>
        Other,
    }
}
