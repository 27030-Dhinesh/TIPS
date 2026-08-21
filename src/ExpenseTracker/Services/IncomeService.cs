using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    /// <summary>
    /// Provides business operations for managing <see cref="Income"/> records.
    /// </summary>
    public class IncomeService
    {
        private readonly IRepository<Income> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The repository used to store and retrieve financial data.
        /// </param>
        public IncomeService(IRepository<Income> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Gets the total number of income entries.
        /// </summary>
        /// <returns>
        /// The number of income entries currently stored in the system.
        /// </returns>
        public int GetIncomeEntriesCount()
        {
            return this._repository.GetEntriesCount();
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
            return this._repository.Add(income);
        }

        /// <summary>
        /// Updates an existing income record.
        /// </summary>
        /// <param name="index">
        /// The unique identifier of the income record to update.
        /// </param>
        /// <param name="updatedIncome">
        /// The updated income information.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the income record was updated successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public bool EditIncome(int index, Income updatedIncome)
        {
            Guid id = this._repository.GetIdByIndex(index);

            if (id.Equals(Guid.Empty))
            {
                return false;
            }

            return this._repository.Edit(id, updatedIncome);
        }

        /// <summary>
        /// Deletes the income record with the specified identifier.
        /// </summary>
        /// <param name="position">
        /// The unique identifier of the income record to delete.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the income record exists and is deleted successfully; otherwise, <see langword="false"/>.
        /// </returns>
        public bool DeleteIncome(int position)
        {
            Guid id = this._repository.GetIdByIndex(position - 1);

            if (id.Equals(Guid.Empty))
            {
                return false;
            }

            if (this._repository.Contains(id))
            {
                this._repository.Delete(id);
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
            return this._repository.GetAll();
        }

        public List<Income> GetIncomesByCategory(IncomeCategory category)
        {
            return
                this.GetIncomes()
                .Where(entry => entry.Category == category.ToString())
                .ToList();
        }

        /// <summary>
        /// Determines whether the collection of income records is empty.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if no income records exist; otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsIncomesEmpty()
        {
            return this._repository.IsEmpty();
        }
    }
}
