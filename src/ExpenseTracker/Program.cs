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
            IRepository repository = new InMemoryStorage();
            FinanceService manager = new FinanceService(repository);
            FinanceView view = new FinanceView(manager);

            while (true)
            {
                view.DisplayMenu();
                WriteColorLine("Enter your choice:", ConsoleColor.DarkGreen);
                string? userChoice = Console.ReadLine();

                if (Enum.TryParse(userChoice, out MenuOption option))
                {
                    switch (option)
                    {
                        case MenuOption.AddIncome:
                            view.AddIncome();
                            UICleanup();
                            break;

                        case MenuOption.EditIncome:
                            view.EditIncome();
                            UICleanup();
                            break;

                        case MenuOption.DeleteIncome:
                            view.DeleteIncome();
                            UICleanup();
                            break;

                        case MenuOption.ViewIncome:
                            view.ViewIncome();
                            UICleanup(3000);
                            break;

                        case MenuOption.AddExpense:
                            view.AddExpense();
                            UICleanup();
                            break;

                        case MenuOption.EditExpense:
                            view.EditExpense();
                            UICleanup();
                            break;

                        case MenuOption.DeleteExpense:
                            view.DeleteExpense();
                            UICleanup();
                            break;

                        case MenuOption.ViewExpense:
                            view.ViewExpense();
                            UICleanup(3000);
                            break;

                        case MenuOption.ShowSummary:
                            Console.WriteLine(MenuOption.ShowSummary);
                            UICleanup();
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
    }
}