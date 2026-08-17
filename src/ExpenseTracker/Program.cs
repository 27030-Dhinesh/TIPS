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
            IRepository<Income> incomeRepository;
            IRepository<Expense> expenseRepository;

            bool useInMemory = true;

            WriteColorLine("Do you want to use CSV Repository? [Y/N]", ConsoleColor.DarkBlue);
            string? choice = Console.ReadLine();
            if (choice is not null && choice.Trim().Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                useInMemory = false;
                WriteColorLine("Selected CSV Repository...", ConsoleColor.DarkBlue);
            }
            else
            {
                WriteColorLine("Using in-memory repository...", ConsoleColor.DarkBlue);
            }

            ConfigureRepositoryType(out incomeRepository, out expenseRepository, useInMemory);
            UICleanup();

            IncomeService incomeManager = new IncomeService(incomeRepository);
            IncomeView incomeView = new IncomeView(incomeManager);

            ExpenseService expenseManager = new ExpenseService(expenseRepository);
            ExpenseView expenseView = new ExpenseView(expenseManager);

            SummaryService summaryService = new SummaryService(incomeRepository, expenseRepository);
            SummaryView summaryView = new SummaryView(summaryService);

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
                            summaryView.ShowSummary();
                            UICleanup(waitForUser: true);
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

        private static void ConfigureRepositoryType(out IRepository<Income> incomeRepository, out IRepository<Expense> expenseRepository, bool useInMemory)
        {
            if (useInMemory)
            {
                incomeRepository = new InMemoryStorage<Income>();
                expenseRepository = new InMemoryStorage<Expense>();
                return;
            }

            incomeRepository = new CSVRepository<Income>("incomes.csv");
            expenseRepository = new CSVRepository<Expense>("expenses.csv");
        }

        private static void ExpenseManagement(ExpenseView expenseView)
        {
            Console.Clear();
            while (true)
            {
                expenseView.DisplayExpenseMenu();
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
                            UICleanup(waitForUser: true);
                            break;

                        case ExpenseMenu.ViewByCategory:
                            expenseView.ViewExpensesByCategory();
                            UICleanup(waitForUser: true);
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
            Console.Clear();
            while (true)
            {
                incomeView.DisplayIncomeMenu();
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
                            UICleanup(waitForUser: true);
                            break;

                        case IncomeMenu.ViewByCategory:
                            incomeView.ViewIncomesByCategory();
                            UICleanup(waitForUser: true);
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
    }
}
