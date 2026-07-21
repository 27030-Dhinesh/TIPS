using ShapeHierarchy.Models;
using ShapeHierarchy.Services;
using static ShapeHierarchy.ConsoleOperation;

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
            string userChoice;
            ShapeService service = new ();

            while (true)
            {
                DisplayAppInfo();
                userChoice = GetInput("Enter your Choice:", "Invalid choice, try again.");

                switch (userChoice)
                {
                    case "1":
                        HandleRectangle(service);
                        break;
                    case "2":
                        HandleCircle(service);
                        break;
                    case "3":
                        Console.WriteLine("Exiting application...");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }

        private static void HandleCircle(ShapeService shapeService)
        {
            double radius = GetRadius("Enter radius of the circle: ", "Invalid input, try again.");

            Circle circle = shapeService.CreateCircle(radius);

            Console.WriteLine(circle.PrintDetails());

            Console.WriteLine($"Area of the Circle: {circle.CalculateArea()}");
        }

        private static void HandleRectangle(ShapeService shapeService)
        {
            double width = GetWidth("Enter width of the rectangle: ", "Invalid input, try again.");
            double height = GetWidth("Enter height of the rectangle: ", "Invalid input, try again.");

            Rectangle rectangle = shapeService.CreateRectangle(width, height);

            Console.WriteLine(rectangle.PrintDetails());

            Console.WriteLine($"Area of the Rectangle: {rectangle.CalculateArea()}");
        }
    }
}