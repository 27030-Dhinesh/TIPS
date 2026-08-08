using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    /// <summary>
    /// Provides business logic and coordinates financial management operations.
    /// </summary>
    public class FinanceService
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository used to store and retrieve financial data.
        /// </param>
        public FinanceService(IRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Adds a new income record.
        /// </summary>
        /// <param name="income">
        /// The income record to add.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the income was added successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public bool AddIncome(Income income)
        {
            return this._repository.AddIncome(income);
        }

        /// <summary>
        /// Adds a new expense record.
        /// </summary>
        /// <param name="expense">
        /// The expense record to add.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the expense was added successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public bool AddExpense(Expense expense)
        {
            return this._repository.AddExpense(expense);
        }

        /// <summary>
        /// Updates an existing income record.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the income record to update.
        /// </param>
        /// <param name="updatedIncome">
        /// The updated income information.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the income record was updated successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public bool EditIncome(Guid id, Income updatedIncome)
        {
            return this._repository.EditIncome(id, updatedIncome);
        }

        /// <summary>
        /// Updates an existing expense record.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the expense record to update.
        /// </param>
        /// <param name="updatedExpense">
        /// The updated expense information.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the expense record was updated successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public bool EditExpense(Guid id, Expense updatedExpense)
        {
            return this._repository.EditExpense(id, updatedExpense);
        }

        /// <summary>
        /// Deletes the income record with the specified identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the income record to delete.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the income record exists and is deleted successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public bool DeleteIncome(Guid id)
        {
            if (this._repository.ContainsIncome(id))
            {
                this._repository.DeleteIncome(id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes the expense record with the specified identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the expense record to delete.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the expense record exists and is deleted successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public bool DeleteExpense(Guid id)
        {
            if (this._repository.ContainsExpense(id))
            {
                this._repository.DeleteExpense(id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves all income records.
        /// </summary>
        /// <returns>
        /// A list containing all income records.
        /// </returns>
        public List<Income> GetIncomes()
        {
            return this._repository.GetIncomes();
        }

        /// <summary>
        /// Retrieves all expense records.
        /// </summary>
        /// <returns>
        /// A list containing all expense records.
        /// </returns>
        public List<Expense> GetExpenses()
        {
            return this._repository.GetExpenses();
        }

        /// <summary>
        /// Determines whether the collection of income records is empty.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if no income records exist; otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsIncomesEmpty()
        {
            return this._repository.IsIncomesEmpty();
        }

        /// <summary>
        /// Determines whether the collection of expense records is empty.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if no expense records exist; otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsExpensesEmpty()
        {
            return this._repository.IsExpensesEmpty();
        }
    }
}
