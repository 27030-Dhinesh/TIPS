using BankingSystem;

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
            SavingsAccount account = new ()
            {
                Balance = 30000m,
            };

            account.Deposit(500m);

            account.Withdraw(700m);

            Console.WriteLine(account.Balance);

            Console.ReadKey();
        }
    }
}