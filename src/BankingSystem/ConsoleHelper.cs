using static BankingSystem.ValidationHelper;

namespace BankingSystem
{
    /// <summary>
    /// Console Operations to support the View layer.
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Display app menu for user choices.
        /// </summary>
        /// <param name="type">The type of Bank Account for which info needs to be shown to user.</param>
        public static void DisplayAppInfo()
        {
            Console.WriteLine($@"1. Create a Savings Account
2. Create a Checking Account
3. Withdraw Money from Account
4. Deposit Money to Account
5. Display Account details
6. Close Account
7. Exit");
        }

        /// <summary>
        /// Get a non-null, non-whitespace input from user.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>A non-null, non-whitespace string input from user.</returns>
        public static string GetInput(string prompt, string errorMessage)
        {
            string? choice;
            do
            {
                Console.WriteLine(prompt);
                choice = Console.ReadLine();
                if (string.IsNullOrEmpty(choice) || string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    return choice;
                }
            }
            while (true);
        }

        /// <summary>
        /// Get a valid customer name from the user.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>A validate name of the customer.</returns>
        public static string GetName(string prompt, string errorMessage)
        {
            do
            {
                string name = GetInput(prompt, errorMessage);
                if (IsValidName(name))
                {
                    return name;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
            while (true);
        }

        /// <summary>
        /// Get a valid account number from the user.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>A valid account number.</returns>
        public static string GetAccountNumber(string prompt, string errorMessage)
        {
            do
            {
                string accountNumber = GetInput(prompt, errorMessage);
                if (IsValidAccountNumber(accountNumber))
                {
                    return accountNumber;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
            while (true);
        }

        /// <summary>
        /// Get a valid amount input from the user.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>A valid amount.</returns>
        public static decimal GetAmount(string prompt, string errorMessage)
        {
            do
            {
                Console.WriteLine(prompt);
                decimal amount;
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    return amount;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
            while (true);
        }
    }
}
