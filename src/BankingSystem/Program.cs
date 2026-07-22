using BankingSystem.Models;
using BankingSystem.Repository;
using BankingSystem.Services;
using static BankingSystem.ConsoleHelper;

namespace Assignments
{
    /// <summary>
    /// Main Program class for the Shape Hierarchy Task.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Method - Entry point of the program.
        /// </summary>
        /// <param name="args">Arguments from the CLI.</param>
        public static void Main(string[] args)
        {
            BankAccountRepository repository = new BankAccountRepository();
            BankingSystemService service = new (repository);

            string userChoice;

            while (true)
            {
                DisplayAppInfo(AccountType.Savings);
                userChoice = GetInput("Enter your Choice:", "Invalid choice, try again.");

                switch (userChoice)
                {
                    case "1":
                        HandleAccountCreation(service, AccountType.Savings);
                        break;
                    case "2":
                        HandleAccountDeposit(service, AccountType.Savings);
                        break;
                    case "3":
                        Console.WriteLine("Exiting application...");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }

            Console.ReadKey();
        }

        private static void HandleAccountDeposit(BankingSystemService service, AccountType savings)
        {
        }

        private static void HandleAccountCreation(BankingSystemService service, AccountType savings)
        {
        }
    }
}