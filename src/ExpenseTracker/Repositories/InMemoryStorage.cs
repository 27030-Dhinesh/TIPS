using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repositories
{
    /// <summary>
    /// Provides an in-memory repository for storing and managing application data.
    /// </summary>
    internal class InMemoryStorage : IRepository
    {
        private readonly List<Income> _incomes = new ();
        private readonly List<Expense> _expenses = new ();

        /// <inheritdoc/>
        public bool AddExpense(Expense expense)
        {
            this._expenses.Add(expense);
            return true;
        }

        /// <inheritdoc/>
        public bool AddIncome(Income income)
        {
            this._incomes.Add(income);
            return true;
        }

        /// <inheritdoc/>
        public bool ContainsExpense(Guid id)
        {
            return this._expenses.Any(entry => entry.Id == id);
        }

        /// <inheritdoc/>
        public bool ContainsIncome(Guid id)
        {
            return this._incomes.Any(entry => entry.Id == id);
        }

        /// <inheritdoc/>
        public bool DeleteExpense(Guid id)
        {
            return this._expenses.RemoveAll(entry => entry.Id == id) > 0;
        }

        /// <inheritdoc/>
        public bool DeleteIncome(Guid id)
        {
            return this._incomes.RemoveAll(entry => entry.Id == id) > 0;
        }

        /// <inheritdoc/>
        public bool EditExpense(Guid id, Expense updatedExpense)
        {
            Expense oldExpense = this.GetExpenseById(id);
            oldExpense.Id = updatedExpense.Id;
            oldExpense.Amount = updatedExpense.Amount;
            oldExpense.Date = updatedExpense.Date;
            oldExpense.Category = updatedExpense.Category;

            return true;
        }

        /// <inheritdoc/>
        public bool EditIncome(Guid id, Income updatedIncome)
        {
            Income oldIncome = this.GetIncomeById(id);
            oldIncome.Id = updatedIncome.Id;
            oldIncome.Amount = updatedIncome.Amount;
            oldIncome.Date = updatedIncome.Date;
            oldIncome.Category = updatedIncome.Category;

            return true;
        }

        /// <inheritdoc/>
        public int GetExpenseEntriesCount()
        {
            return this._expenses.Count;
        }

        /// <inheritdoc/>
        public List<Expense> GetExpenses()
        {
            return this._expenses.Select(item => item.Clone()).ToList();
        }

        /// <inheritdoc/>
        public List<Income> GetIncomes()
        {
            return this._incomes.Select(item => item.Clone()).ToList();
        }

        /// <inheritdoc/>
        public int GetIncomeEntriesCount()
        {
            return this._incomes.Count;
        }

        /// <inheritdoc/>
        public bool IsExpensesEmpty()
        {
            return this._expenses.Count == 0;
        }

        /// <inheritdoc/>
        public bool IsIncomesEmpty()
        {
            return this._incomes.Count == 0;
        }

        /// <inheritdoc/>
        public Guid GetIncomeIdByIndex(int index)
        {
            if (index < 0 || index >= this._incomes.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return this._incomes[index].Id;
        }

        /// <inheritdoc/>
        public Guid GetExpenseIdByIndex(int index)
        {
            if (index < 0 || index >= this._expenses.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return this._expenses[index].Id;
        }

        // use this.ContainsExpense(id) before calling
        // this method
        private Expense GetExpenseById(Guid id)
        {
            return this._expenses.FirstOrDefault(entry => entry.Id == id) !;
        }

        // use this.ContainsIncome(id) before calling
        // this method
        private Income GetIncomeById(Guid id)
        {
            return this._incomes.FirstOrDefault(entry => entry.Id == id) !;
        }
    }
}
