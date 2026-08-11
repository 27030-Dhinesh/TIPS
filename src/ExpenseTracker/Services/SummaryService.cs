using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public class SummaryService
    {
        private readonly IRepository<Income> _incomeRepository;
        private readonly IRepository<Expense> _expenseRepository;

        public SummaryService(
            IRepository<Income> incomeRepository,
            IRepository<Expense> expenseRepository)
        {
            this._incomeRepository = incomeRepository;
            this._expenseRepository = expenseRepository;
        }

        public decimal GetTotalIncome()
        {
            return this._incomeRepository.GetTotalAmount();
        }

        public decimal GetTotalExpense()
        {
            return this._expenseRepository.GetTotalAmount();
        }

        public decimal GetSummary()
        {
            return this.GetTotalIncome() - this.GetTotalExpense();
        }
    }
}
