using BankingSystem.Models;
using BankingSystem.Repository;
using BankingSystem.Services;
using static BankingSystem.ConsoleHelper;

namespace BankingSystem
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
                DisplayAppInfo();
                userChoice = GetInput("Enter your Choice:", "Invalid choice, try again.");

                switch (userChoice)
                {
                    case "1":
                        HandleAccountCreation(service, AccountType.Savings);
                        break;
                    case "2":
                        HandleDeposit(service, AccountType.Savings);
                        break;
                    case "3":
                        HandleWithdraw(service, AccountType.Savings);
                        break;
                    case "4":
                        HandleAccountCreation(service, AccountType.Checking);
                        break;
                    case "5":
                        HandleDeposit(service, AccountType.Checking);
                        break;
                    case "6":
                        HandleWithdraw(service, AccountType.Checking);
                        break;
                    case "7":
                        Console.WriteLine("Exiting application...");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice, try again.");
                        break;
                }
            }
        }

        private static void HandleAccountCreation(BankingSystemService service, AccountType type)
        {
            // string accountNumber = Console.ReadLine();
            Console.WriteLine($"Handle Creation for {type}");
        }

        private static void HandleWithdraw(BankingSystemService service, AccountType type)
        {
            Console.WriteLine($"Handle withdraw for {type}");
        }

        private static void HandleDeposit(BankingSystemService service, AccountType type)
        {
            Console.WriteLine($"Handle deposit for {type}");
        }
    }
}