using EmployeeHierarchy;

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
            Manager manager = new ()
            {
                Name = "Ram Kumar",
                Salary = 15000m,
            };

            Console.WriteLine(manager.PrintDetails());

            Console.ReadKey();
        }
    }
}