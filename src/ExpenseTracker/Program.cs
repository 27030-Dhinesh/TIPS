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
                DisplayMainMenu();
                WriteColorLine("Enter your choice:", ConsoleColor.DarkGreen);
                string? userChoice = Console.ReadLine();

                if (Enum.TryParse(userChoice, out MenuOption option))
                {
                    switch (option)
                    {
                        case MenuOption.IncomeManagement:
                            IncomeManagement(incomeView);
                            break;

                        case MenuOption.ExpenseManagement:
                            ExpenseManagement(expenseView);
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

        private static void ExpenseManagement(ExpenseView expenseView)
        {
            UICleanup();
            while (true)
            {
                DisplayExpenseMenu();
                WriteColorLine("Enter your choice:", ConsoleColor.DarkGreen);
                string? userChoice = Console.ReadLine();

                if (Enum.TryParse(userChoice, out ExpenseMenu option))
                {
                    switch (option)
                    {
                        case ExpenseMenu.AddExpense:
                            expenseView.AddExpense();
                            UICleanup();
                            break;

                        case ExpenseMenu.EditExpense:
                            expenseView.EditExpense();
                            UICleanup();
                            break;

                        case ExpenseMenu.DeleteExpense:
                            expenseView.DeleteExpense();
                            UICleanup();
                            break;

                        case ExpenseMenu.ViewExpense:
                            expenseView.ViewExpense();
                            UICleanup(3000);
                            break;

                        case ExpenseMenu.SwitchToMainMenu:
                            WriteColorLine("Switching to main menu...", ConsoleColor.DarkYellow);
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

        private static void IncomeManagement(IncomeView incomeView)
        {
            while (true)
            {
                DisplayIncomeMenu();
                WriteColorLine("Enter your choice:", ConsoleColor.DarkGreen);
                string? userChoice = Console.ReadLine();

                if (Enum.TryParse(userChoice, out IncomeMenu option))
                {
                    switch (option)
                    {
                        case IncomeMenu.AddIncome:
                            incomeView.AddIncome();
                            UICleanup();
                            break;

                        case IncomeMenu.EditIncome:
                            incomeView.EditIncome();
                            UICleanup();
                            break;

                        case IncomeMenu.DeleteIncome:
                            incomeView.DeleteIncome();
                            UICleanup();
                            break;

                        case IncomeMenu.ViewIncome:
                            incomeView.ViewIncome();
                            UICleanup(3000);
                            break;

                        case IncomeMenu.SwitchToMainMenu:
                            WriteColorLine("Switching to main menu...", ConsoleColor.DarkYellow);
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

        private static void DisplayMainMenu()
        {
            foreach (MenuOption option in Enum.GetValues<MenuOption>())
            {
                Console.WriteLine($"{(int)option}. {option}");
            }
        }

        private static void DisplayIncomeMenu()
        {
            foreach (IncomeMenu option in Enum.GetValues<IncomeMenu>())
            {
                Console.WriteLine($"{(int)option}. {option}");
            }
        }

        private static void DisplayExpenseMenu()
        {
            foreach (ExpenseMenu option in Enum.GetValues<ExpenseMenu>())
            {
                Console.WriteLine($"{(int)option}. {option}");
            }
        }
    }
}