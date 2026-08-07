using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    /// <summary>
    /// Provides business logic and coordinates financial management operations.
    /// </summary>
    internal class FinanceService
    {
        private readonly IRepository _repository;

        public FinanceService(IRepository repository)
        {
            this._repository = repository;
        }

        public bool AddIncome(Income income)
        {
            return this._repository.AddIncome(income);
        }

        public bool AddExpense(Expense expense)
        {
            return this._repository.AddExpense(expense);
        }

        public bool EditIncome(Guid id, Income updatedIncome)
        {
            return this._repository.EditIncome(id, updatedIncome);
        }

        public bool EditExpense(Guid id, Expense updatedExpense)
        {
            return this._repository.EditExpense(id, updatedExpense);
        }

        public bool DeleteIncome(Guid id)
        {
            if (this._repository.ContainsIncome(id))
            {
                this._repository.DeleteIncome(id);
                return true;
            }

            return false;
        }

        public bool DeleteExpense(Guid id)
        {
            if (this._repository.ContainsExpense(id))
            {
                this._repository.DeleteExpense(id);
                return true;
            }

            return false;
        }

        public List<Income> GetIncomes()
        {
            return this._repository.GetIncomes();
        }

        public List<Expense> GetExpenses()
        {
            return this._repository.GetExpenses();
        }

        public bool IsIncomesEmpty()
        {
            return this._repository.IsIncomesEmpty();
        }

        public bool IsExpensesEmpty()
        {
            return this._repository.IsExpensesEmpty();
        }
    }
}
