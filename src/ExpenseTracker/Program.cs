using ExpenseTracker.Models;
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
            while (true)
            {
                FinanceView.DisplayMenu();
                WriteColorLine("Enter your choice:", ConsoleColor.DarkGreen);
                string? userChoice = Console.ReadLine();

                if (Enum.TryParse(userChoice, out MenuOption option))
                {
                    switch (option)
                    {
                        case MenuOption.AddIncome:
                            break;

                        case MenuOption.EditIncome:
                            break;

                        case MenuOption.DeleteIncome:
                            break;

                        case MenuOption.ViewIncome:
                            break;

                        case MenuOption.AddExpense:
                            break;

                        case MenuOption.EditExpense:
                            break;

                        case MenuOption.DeleteExpense:
                            break;

                        case MenuOption.ViewExpense:
                            break;

                        case MenuOption.ShowSummary:
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