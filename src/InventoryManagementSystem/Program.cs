namespace Assignments
{
    /// <summary>
    /// Contains the main entry point and core initialization logic for the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">An array of command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            float a = 0.2F;
            double b = 0.2;
            bool c = a == b;
            Console.WriteLine(c);

            Console.ReadKey();
        }
    }
}