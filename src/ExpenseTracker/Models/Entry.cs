namespace ExpenseTracker.Models
{
    internal abstract class Entry
    {
        internal Guid Id { get; set; }

        internal decimal Amount { get; set; }

        internal DateTime Date { get; set; }
    }
}
