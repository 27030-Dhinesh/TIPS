using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
        where T : IEntry
    {
        bool IsEmpty();

        int GetEntriesCount();

        bool Add(T entry);

        bool Edit(Guid id, T entry);

        bool Delete(Guid id);

        List<T> GetAll();

        bool Contains(Guid id);

        public Guid GetIdByIndex(int index);
    }
}
