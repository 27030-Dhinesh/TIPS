using ShapeHierarchy.Models;

namespace ShapeHierarchy
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
            Rectangle rectangle = new ()
            {
                Width = 5,
                Height = 7,
            };

            double area = rectangle.CalculateArea();

            Console.WriteLine(area);

            rectangle.PrintDetails();

            Console.ReadKey();
        }
    }
}