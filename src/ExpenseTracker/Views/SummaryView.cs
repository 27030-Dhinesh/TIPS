using ExpenseTracker.Services;
using static ExpenseTracker.Helpers.ConsoleHelper;

namespace ExpenseTracker.Views
{
    public class SummaryView
    {
        private readonly SummaryService _service;

        public SummaryView(SummaryService service)
        {
            this._service = service;
        }

        public void GetSummary()
        {
            decimal totalIncome = this._service.GetTotalIncome();
            decimal totalExpense = this._service.GetTotalExpense();
            decimal netAmount = this._service.GetSummary();

            WriteColorLine(
                $@"Total Income: {totalIncome}
Total Expense: {totalExpense}

Net Balance: {netAmount}",
                ConsoleColor.DarkYellow);
        }
    }
}
