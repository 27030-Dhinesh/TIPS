using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repositories
{
    /// <summary>
    /// Provides an in-memory implementation of <see cref="IRepository{T}"/> for storing
    /// and managing entries during the application's lifetime.
    /// </summary>
    /// <typeparam name="T">
    /// The type of entry managed by the repository. The type must implement
    /// <see cref="IEntry"/>.
    /// </typeparam>
    internal class InMemoryStorage<T> : IRepository<T>
        where T : IEntry
    {
        private readonly List<T> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryStorage{T}"/> class.
        /// </summary>
        public InMemoryStorage()
        {
            this._repository = new List<T>();
        }

        /// <inheritdoc/>
        public bool Add(T entry)
        {
            this._repository.Add(entry);
            return true;
        }

        /// <inheritdoc/>
        public bool Contains(Guid id)
        {
            return this._repository.Any(entry => entry.Id == id);
        }

        /// <inheritdoc/>
        public bool Delete(Guid id)
        {
            return this._repository.RemoveAll(entry => entry.Id == id) > 0;
        }

        /// <inheritdoc/>
        public bool Edit(Guid id, T updatedEntry)
        {
            T oldEntry = this.GetById(id);
            oldEntry.Id = updatedEntry.Id;
            oldEntry.Amount = updatedEntry.Amount;
            oldEntry.Date = updatedEntry.Date;
            oldEntry.Category = updatedEntry.Category;

            return true;
        }

        /// <inheritdoc/>
        public List<T> GetAll()
        {
            return this._repository.Select(item => (T)item.Clone()).ToList();
        }

        /// <inheritdoc/>
        public int GetEntriesCount()
        {
            return this._repository.Count;
        }

        /// <inheritdoc/>
        public Guid GetIdByIndex(int index)
        {
            return this._repository[index].Id;
        }

        /// <inheritdoc/>
        public bool IsEmpty()
        {
            return this._repository.Count == 0;
        }

        /// <inheritdoc/>
        public decimal GetTotalAmount()
        {
            return this._repository.Sum(entry => entry.Amount);
        }

        private T GetById(Guid id)
        {
            return this._repository.FirstOrDefault(entry => entry.Id == id) !;
        }
    }
}
