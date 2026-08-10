using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repositories
{
    internal class InMemoryStorage<T> : IRepository<T>
        where T : IEntry
    {
        private readonly List<T> _repository = new List<T>();

        public bool Add(T entry)
        {
            this._repository.Add(entry);
            return true;
        }

        public bool Contains(Guid id)
        {
            return this._repository.Any(entry => entry.Id == id);
        }

        public bool Delete(Guid id)
        {
            return this._repository.RemoveAll(entry => entry.Id == id) > 0;
        }

        public bool Edit(Guid id, T updatedEntry)
        {
            T oldEntry = this.GetById(id);
            oldEntry.Id = updatedEntry.Id;
            oldEntry.Amount = updatedEntry.Amount;
            oldEntry.Date = updatedEntry.Date;
            oldEntry.Category = updatedEntry.Category;

            return true;
        }

        public List<T> GetAll()
        {
            return this._repository.Select(item => (T)item.Clone()).ToList();
        }

        public int GetEntriesCount()
        {
            return this._repository.Count;
        }

        public Guid GetIdByIndex(int index)
        {
            return this._repository[index].Id;
        }

        public bool IsEmpty()
        {
            return this._repository.Count == 0;
        }

        private T GetById(Guid id)
        {
            return this._repository.FirstOrDefault(entry => entry.Id == id) !;
        }
    }
}
