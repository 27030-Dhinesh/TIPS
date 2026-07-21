using static EmployeeHierarchy.ValidationHelper;

namespace EmployeeHierarchy
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
            Console.WriteLine($@"1. Manager
2. Developer
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

        /// <summary>
        /// Get valid Name for the Employee.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>Valid string for Name of the Employee.</returns>
        public static string GetName(string prompt, string errorMessage)
        {
            string name = string.Empty;
            do
            {
                name = GetInput(prompt, errorMessage);
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
        /// Get valid Salary for the Employee.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>Valid decimal for Salary of the Employee.</returns>
        public static decimal GetSalary(string prompt, string errorMessage)
        {
            return GetDecimal(prompt, errorMessage);
        }

        private static decimal GetDecimal(string prompt, string errorMessage)
        {
            do
            {
                Console.WriteLine(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                {
                    return result;
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
