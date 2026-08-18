using ExpenseTracker.Services;
using static ExpenseTracker.Helpers.ConsoleHelper;

namespace ExpenseTracker.Views
{
    /// <summary>
    /// Provides functionality for displaying financial summary information
    /// to the user.
    /// </summary>
    public class SummaryView
    {
        private readonly SummaryService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryView"/> class.
        /// </summary>
        /// <param name="service">
        /// The summary service used to retrieve financial data.
        /// </param>
        public SummaryView(SummaryService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Retrieves and displays the total income, total expense,
        /// and net balance information to the console.
        /// </summary>
        public void ShowSummary()
        {
            Dictionary<string, decimal> results = this._service.GenerateSummary();

            foreach (KeyValuePair<string, decimal> kvp in results)
            {
                WriteColorLine($"{kvp.Key}\t:{kvp.Value}", ConsoleColor.Blue);
            }

            decimal totalIncome = this._service.GetTotalIncome();
            decimal totalExpense = this._service.GetTotalExpense();
            decimal netAmount = totalIncome - totalExpense;

            WriteColorLine(
                $@"Total Income: {totalIncome}
Total Expense: {totalExpense}

Net Balance: {netAmount}",
                ConsoleColor.DarkYellow);
        }
    }
}
