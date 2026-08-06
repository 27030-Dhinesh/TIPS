using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces
{
    internal interface IRepository
    {
        internal bool IsEmpty();

        internal bool AddRecord(Entry entry);

        internal bool UpdateRecord(Guid expenseId, Entry updatedEntry);

        internal List<Entry> GetAllRecords();

        internal bool DeleteRecord(Guid id);
    }
}
