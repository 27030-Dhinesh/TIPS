using static BankingSystem.ValidationHelper;

namespace BankingSystem
{
    /// <summary>
    /// Console Operations to support the View layer.
    /// </summary>
    internal static class ConsoleHelper
    {
        private const int TRIES = 3;

        /// <summary>
        /// Display app menu for user choices.
        /// </summary>
        public static void DisplayAppInfo()
        {
            Console.WriteLine($@"1. Create a Savings Account
2. Create a Checking Account
3. Withdraw Money from Account
4. Deposit Money to Account
5. Display Account details
6. Close Account
7. Exit

Enter your choice:");
        }

        /// <summary>
        /// Get a valid customer name from the user.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>A validate name of the customer.</returns>
        public static string GetName(string prompt, string errorMessage)
        {
            int tries = TRIES;
            string? name;
            do
            {
                Console.WriteLine(prompt);
                name = Console.ReadLine();
                if (!IsValidName(name))
                {
                    Console.WriteLine($"{errorMessage} {--tries} tries left.");
                    continue;
                }

                return name!.Trim();
            }
            while (tries > 0);

            return string.Empty;
        }

        /// <summary>
        /// Get a valid account number from the user.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>A valid account number.</returns>
        public static string GetAccountNumber(string prompt, string errorMessage)
        {
            int tries = TRIES;
            string? accountNumber;
            do
            {
                Console.WriteLine(prompt);
                accountNumber = Console.ReadLine();
                if (IsValidAccountNumber(accountNumber))
                {
                    return accountNumber!.Trim();
                }
                else
                {
                    Console.WriteLine($"{errorMessage} {--tries} tries left.");
                }
            }
            while (tries > 0);

            return string.Empty;
        }

        /// <summary>
        /// Get a valid amount input from the user.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>A valid amount.</returns>
        public static decimal GetAmount(string prompt, string errorMessage)
        {
            int tries = TRIES;

            do
            {
                Console.WriteLine(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    return amount;
                }
                else
                {
                    Console.WriteLine($"{errorMessage} {--tries} tries left.");
                }
            }
            while (tries > 0);

            return decimal.Zero;
        }
    }
}
