using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    internal class ExpenseService
    {
        private readonly IRepository<Expense> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository used to store and retrieve financial data.
        /// </param>
        public ExpenseService(IRepository<Expense> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Gets the total number of expense entries.
        /// </summary>
        /// <returns>
        /// The number of expense entries currently stored in the system.
        /// </returns>
        public int GetExpenseEntriesCount()
        {
            return this._repository.GetEntriesCount();
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
            return this._repository.Add(expense);
        }

        /// <summary>
        /// Updates an existing expense record.
        /// </summary>
        /// <param name="index">
        /// The unique identifier of the expense record to update.
        /// </param>
        /// <param name="updatedExpense">
        /// The updated expense information.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the expense record was updated successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public bool EditExpense(int index, Expense updatedExpense)
        {
            Guid id = this._repository.GetIdByIndex(index);

            return this._repository.Edit(id, updatedExpense);
        }

        /// <summary>
        /// Deletes the expense record with the specified identifier.
        /// </summary>
        /// <param name="position">
        /// The unique identifier of the expense record to delete.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the expense record exists and is deleted successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public bool DeleteExpense(int position)
        {
            Guid id = this._repository.GetIdByIndex(position - 1);

            if (this._repository.Contains(id))
            {
                this._repository.Delete(id);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves all expense records.
        /// </summary>
        /// <returns>
        /// A list containing all expense records.
        /// </returns>
        public List<Expense> GetExpenses()
        {
            return this._repository.GetAll();
        }

        /// <summary>
        /// Determines whether the collection of expense records is empty.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if no expense records exist; otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsExpensesEmpty()
        {
            return this._repository.IsEmpty();
        }
    }
}
