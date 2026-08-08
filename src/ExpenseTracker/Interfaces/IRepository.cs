using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces
{
    /// <summary>
    /// Defines a repository for performing CRUD operations on income and expense records.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Determines whether the income collection contains any records.
        /// </summary>
        /// <returns>
        /// <c>true</c> if no income records exist; otherwise, <c>false</c>.
        /// </returns>
        bool IsIncomesEmpty();

        /// <summary>
        /// Determines whether the expense collection contains any records.
        /// </summary>
        /// <returns>
        /// <c>true</c> if no expense records exist; otherwise, <c>false</c>.
        /// </returns>
        bool IsExpensesEmpty();

        /// <summary>
        /// Adds a new expense record to the repository.
        /// </summary>
        /// <param name="expense">
        /// The expense to add.
        /// </param>
        /// <returns>
        /// <c>true</c> if the expense was added successfully; otherwise, <c>false</c>.
        /// </returns>
        bool AddExpense(Expense expense);

        /// <summary>
        /// Adds a new income record to the repository.
        /// </summary>
        /// <param name="income">
        /// The income to add.
        /// </param>
        /// <returns>
        /// <c>true</c> if the income was added successfully; otherwise, <c>false</c>.
        /// </returns>
        bool AddIncome(Income income);

        /// <summary>
        /// Updates an existing expense record.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the expense to update.
        /// </param>
        /// <param name="updatedExpense">
        /// The updated expense information.
        /// </param>
        /// <returns>
        /// <c>true</c> if the expense was updated successfully; otherwise, <c>false</c>.
        /// </returns>
        bool EditExpense(Guid id, Expense updatedExpense);

        /// <summary>
        /// Updates an existing income record.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the income to update.
        /// </param>
        /// <param name="income">
        /// The updated income information.
        /// </param>
        /// <returns>
        /// <c>true</c> if the income was updated successfully; otherwise, <c>false</c>.
        /// </returns>
        bool EditIncome(Guid id, Income income);

        /// <summary>
        /// Deletes an expense record from the repository.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the expense to delete.
        /// </param>
        /// <returns>
        /// <c>true</c> if the expense was deleted successfully; otherwise, <c>false</c>.
        /// </returns>
        bool DeleteExpense(Guid id);

        /// <summary>
        /// Deletes an income record from the repository.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the income to delete.
        /// </param>
        /// <returns>
        /// <c>true</c> if the income was deleted successfully; otherwise, <c>false</c>.
        /// </returns>
        bool DeleteIncome(Guid id);

        /// <summary>
        /// Retrieves all expense records from the repository.
        /// </summary>
        /// <returns>
        /// A list containing all expense records.
        /// </returns>
        List<Expense> GetExpenses();

        /// <summary>
        /// Retrieves all income records from the repository.
        /// </summary>
        /// <returns>
        /// A list containing all income records.
        /// </returns>
        List<Income> GetIncomes();

        /// <summary>
        /// Determines whether an expense record with the specified identifier
        /// exists in the repository.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the expense to locate.
        /// </param>
        /// <returns>
        /// <c>true</c> if an expense with the specified identifier exists; otherwise, <c>false</c>.
        /// </returns>
        bool ContainsExpense(Guid id);

        /// <summary>
        /// Determines whether an income record with the specified identifier
        /// exists in the repository.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the income to locate.
        /// </param>
        /// <returns>
        /// <c>true</c> if an income with the specified identifier exists; otherwise, <c>false</c>.
        /// </returns>
        bool ContainsIncome(Guid id);
    }
}
