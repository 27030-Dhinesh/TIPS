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

            string? userChoice;

            while (true)
            {
                DisplayAppInfo();
                userChoice = Console.ReadLine();
                if (userChoice != null)
                {
                    userChoice = userChoice.Trim();
                }

                switch (userChoice)
                {
                    case "1":
                        HandleAccountCreation(service, AccountType.Savings);
                        break;
                    case "2":
                        HandleAccountCreation(service, AccountType.Checking);
                        break;
                    case "3":
                        HandleTransaction(service, TransactionType.Withdraw);
                        break;
                    case "4":
                        HandleTransaction(service, TransactionType.Deposit);
                        break;
                    case "5":
                        HandleDisplay(service);
                        break;
                    case "6":
                        HandleDeletion(service);
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
            string name = GetName("Enter the name:", "Invalid input for name, try again.");
            if (name.Equals(string.Empty))
            {
                Console.WriteLine("Switching to main menu...");
                return;
            }

            string accountNumber;
            BankAccount account;
            switch (type)
            {
                case AccountType.Savings:
                    account = new SavingsAccount(name, 500m);
                    accountNumber = service.AddAccount(account);
                    Console.WriteLine($"Your account number is {accountNumber}\nCreation successful, with initial balance Rs.500/-");
                    break;

                case AccountType.Checking:
                    account = new CheckingAccount(name, 1000m);
                    accountNumber = service.AddAccount(account);
                    Console.WriteLine($"Your account number is {accountNumber}\nCreation successful, with initial balance Rs.1000/-");
                    break;
            }
        }

        private static void HandleTransaction(BankingSystemService service, TransactionType type)
        {
            string accountNumber = GetAccountNumber("Enter account no:", "Invalid account number, try again.");
            if (accountNumber.Equals(string.Empty))
            {
                Console.WriteLine("Switching to main menu...");
                return;
            }

            decimal amount = GetAmount($"Enter amount to {type}:", "Invalid amount, try again.");
            if (amount == 0)
            {
                Console.WriteLine("Switching to main menu...");
                return;
            }

            bool status = service.Transaction(accountNumber, type, amount);

            if (status)
            {
                Console.WriteLine($"{type} successful.");
            }
            else
            {
                Console.WriteLine($"{type} failed, try again later.");
            }
        }

        private static void HandleDisplay(BankingSystemService service)
        {
            string accountNumber = GetAccountNumber("Enter the account number:", "Invalid input for account number, try again.");
            if (accountNumber.Equals(string.Empty))
            {
                Console.WriteLine("Switching to main menu...");
                return;
            }

            BankAccount? account = service.GetAccount(accountNumber);

            if (account != null)
            {
                Console.WriteLine(account);
            }
            else
            {
                Console.WriteLine("Failed to fetch account, invalid account number.");
            }
        }

        private static void HandleDeletion(BankingSystemService service)
        {
            string accountNumber = GetAccountNumber("Enter the account number:", "Invalid input for account number, try again.");
            if (accountNumber.Equals(string.Empty))
            {
                Console.WriteLine("Switching to main menu...");
                return;
            }

            if (service.DeleteAccount(accountNumber))
            {
                Console.WriteLine("Account closed successfully.");
            }
            else
            {
                Console.WriteLine("Failed to close account.");
            }
        }
    }
}