using ExpenseTracker.Interfaces;
using ExpenseTracker.Models;
using ExpenseTracker.Repositories;
using ExpenseTracker.Services;
using ExpenseTracker.Views;
using static ExpenseTracker.Helpers.ConsoleHelper;

namespace ExpenseTracker
{
    /// <summary>
    /// Provides the entry point for the finance management application.
    /// </summary>
    /// <remarks>
    /// Responsible for initializing application components and starting the
    /// application's execution flow.
    /// </remarks>
    public class Program
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        /// <param name="args">
        /// An array of command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            IRepository<Income> incomeRepository = new InMemoryStorage<Income>();
            IncomeService incomeManager = new IncomeService(incomeRepository);
            IncomeView incomeView = new IncomeView(incomeManager);

            IRepository<Expense> expenseRepository = new InMemoryStorage<Expense>();
            ExpenseService expenseManager = new ExpenseService(expenseRepository);
            ExpenseView expenseView = new ExpenseView(expenseManager);

            while (true)
            {
                DisplayMenu();
                WriteColorLine("Enter your choice:", ConsoleColor.DarkGreen);
                string? userChoice = Console.ReadLine();

                if (Enum.TryParse(userChoice, out MenuOption option))
                {
                    switch (option)
                    {
                        case MenuOption.AddIncome:
                            incomeView.AddIncome();
                            UICleanup();
                            break;

                        case MenuOption.EditIncome:
                            incomeView.EditIncome();
                            UICleanup();
                            break;

                        case MenuOption.DeleteIncome:
                            incomeView.DeleteIncome();
                            UICleanup();
                            break;

                        case MenuOption.ViewIncome:
                            incomeView.ViewIncome();
                            UICleanup(3000);
                            break;

                        case MenuOption.AddExpense:
                            expenseView.AddExpense();
                            UICleanup();
                            break;

                        case MenuOption.EditExpense:
                            expenseView.EditExpense();
                            UICleanup();
                            break;

                        case MenuOption.DeleteExpense:
                            expenseView.DeleteExpense();
                            UICleanup();
                            break;

                        case MenuOption.ViewExpense:
                            expenseView.ViewExpense();
                            UICleanup(3000);
                            break;

                        case MenuOption.ShowSummary:
                            Console.WriteLine(MenuOption.ShowSummary);
                            UICleanup(3000);
                            break;

                        case MenuOption.Exit:
                            WriteColorLine("Exiting application...", ConsoleColor.DarkYellow);
                            UICleanup();
                            return;

                        default:
                            WriteColorLine("Invalid option...", ConsoleColor.Red);
                            UICleanup();
                            break;
                    }
                }
                else
                {
                    WriteColorLine("Invalid option...", ConsoleColor.Red);
                    UICleanup();
                }
            }
        }

        private static void DisplayMenu()
        {
            foreach (MenuOption option in Enum.GetValues<MenuOption>())
            {
                Console.WriteLine($"{(int)option}. {option}");
            }
        }
    }
}