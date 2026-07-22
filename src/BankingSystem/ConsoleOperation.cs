namespace BankingSystem
{
    /// <summary>
    /// Console Operations to support the View layer.
    /// </summary>
    internal class ConsoleOperation
    {
        /// <summary>
        /// Display app menu for user choices.
        /// </summary>
        public static void DisplayAppInfo()
        {
            Console.WriteLine($@"1. Create a Savings Account
2. Create a Checking Account
3. Exit");
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
    }
}
