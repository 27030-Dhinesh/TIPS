using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    /// <summary>
    /// Provides functionality for retrieving income and expense totals
    /// and calculating the overall financial summary.
    /// </summary>
    public class SummaryService
    {
        private readonly IRepository<Income> _incomeRepository;
        private readonly IRepository<Expense> _expenseRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryService"/> class.
        /// </summary>
        /// <param name="incomeRepository">
        /// The repository used to retrieve income-related data.
        /// </param>
        /// <param name="expenseRepository">
        /// The repository used to retrieve expense-related data.
        /// </param>
        public SummaryService(
            IRepository<Income> incomeRepository,
            IRepository<Expense> expenseRepository)
        {
            this._incomeRepository = incomeRepository;
            this._expenseRepository = expenseRepository;
        }

        /// <summary>
        /// Retrieves the total income amount from the income repository.
        /// </summary>
        /// <returns>
        /// The sum of all recorded income amounts.
        /// </returns>
        public decimal GetTotalIncome()
        {
            return this._incomeRepository.GetTotalAmount();
        }

        /// <summary>
        /// Retrieves the total expense amount from the expense repository.
        /// </summary>
        /// <returns>
        /// The sum of all recorded expense amounts.
        /// </returns>
        public decimal GetTotalExpense()
        {
            return this._expenseRepository.GetTotalAmount();
        }

        /// <summary>
        /// Calculates the financial summary by subtracting total expenses
        /// from total income.
        /// </summary>
        /// <returns>
        /// The net balance, where a positive value indicates a surplus
        /// and a negative value indicates a deficit.
        /// </returns>
        public Dictionary<string, decimal> GenerateSummary()
        {
            Dictionary<string, decimal> categoryTotals = new Dictionary<string, decimal>();

            foreach (IEntry entry in this._incomeRepository.GetAll())
            {
                if (categoryTotals.TryGetValue(entry.Category, out decimal value))
                {
                    categoryTotals[entry.Category] = value + entry.Amount;
                }
                else
                {
                    categoryTotals[entry.Category] = entry.Amount;
                }
            }

            foreach (IEntry entry in this._expenseRepository.GetAll())
            {
                if (categoryTotals.TryGetValue(entry.Category, out decimal value))
                {
                    categoryTotals[entry.Category] = value + entry.Amount;
                }
                else
                {
                    categoryTotals[entry.Category] = entry.Amount;
                }
            }

            return categoryTotals;
        }
    }
}
