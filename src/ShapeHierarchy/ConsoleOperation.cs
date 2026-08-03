namespace ShapeHierarchy
{
    /// <summary>
    /// Console Operations to support the View layer.
    /// </summary>
    internal static class ConsoleOperation
    {
        private const int TRIES = 3;

        /// <summary>
        /// Display app menu for user choices.
        /// </summary>
        public static void DisplayAppInfo()
        {
            Console.WriteLine($@"1. Create a Rectangle
2. Create a Circle
3. Exit

Enter your choice:");
        }

        /// <summary>
        /// Get valid Width for the Rectangle Shape.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>Valid double for Width of Rectangle Shape.</returns>
        public static double GetWidth(string prompt, string errorMessage)
        {
            return GetDouble(prompt, errorMessage);
        }

        /// <summary>
        /// Get valid Height for the Rectangle Shape.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>Valid double for Height of Rectangle Shape.</returns>
        public static double GetHeight(string prompt, string errorMessage)
        {
            return GetDouble(prompt, errorMessage);
        }

        /// <summary>
        /// Get valid Radius for the Circle Shape.
        /// </summary>
        /// <param name="prompt">Prompt to display when asking input.</param>
        /// <param name="errorMessage">Message to display when user input is invalid.</param>
        /// <returns>Valid double for Radius of Circle Shape.</returns>
        public static double GetRadius(string prompt, string errorMessage)
        {
            return GetDouble(prompt, errorMessage);
        }

        private static double GetDouble(string prompt, string errorMessage)
        {
            for (int i = TRIES; i > 0;)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine(), out double result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"{errorMessage} {--i} tries left");
                }
            }

            return double.NaN;
        }
    }
}
