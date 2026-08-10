using static EmployeeHierarchy.ValidationHelper;

namespace EmployeeHierarchy
{
    /// <summary>
    /// Console Operations to support the View layer.
    /// </summary>
    internal class ConsoleOperation
    {
        private const int TRIES = 3;

        /// <summary>
        /// Display app menu for user choices.
        /// </summary>
        public static void DisplayAppInfo()
        {
            Console.WriteLine($@"1. Manager
2. Developer
3. Exit

Enter your choice:");
        }

        /// <summary>
        /// Get valid Name for the Employee.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>Valid string for Name of the Employee.</returns>
        public static string GetName(string prompt, string errorMessage)
        {
            string? name;
            for (int i = TRIES; i > 0;)
            {
                Console.WriteLine(prompt);
                name = Console.ReadLine();
                if (IsValidName(name))
                {
                    return name!.Trim();
                }
                else
                {
                    Console.WriteLine($"{errorMessage} {--i} tries left.");
                }
            }

            return string.Empty;
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
            for (int i = TRIES; i > 0;)
            {
                Console.WriteLine(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"{errorMessage} {--i} tries left");
                }
            }

            return decimal.Zero;
        }
    }
}
