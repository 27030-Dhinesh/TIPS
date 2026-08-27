using LinqExpression.Models;
using LinqExpression.Tasks;
using static LinqExpression.Helpers.DataPopulatorHelper;

namespace LinqExpression
{
    /// <summary>
    /// Provides the entry point for the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">
        /// The command-line arguments passed to the application.
        /// </param>
        public static void Main(string[] args)
        {
            var context = new SampleDatabaseContext();
            context.Products = GenerateSampleProducts();
            context.Orders = GenerateSampleOrderItems();
            context.Suppliers = GenerateSampleSuppliers();

            TaskOne taskOne = new TaskOne(context.Products);
            TaskTwo taskTwo = new TaskTwo(context.Products, context.Suppliers);
            TaskThreeAndFour taskThree = new TaskThreeAndFour(count: 20, target: 30);

            while (true)
            {
                Console.Write(@"LINQ EXPRESSIONS
1. Average price of Electronics products worth more than $5000
2. Grouping and Inner Join
3. 2nd Highest Number and Target Sum in Array
4. Performance Optimization
5. Query Builder (Fluent API Pattern)
6. Exit

Enter your choice: ");

                ConsoleKey userChoice = Console.ReadKey().Key;
                Console.WriteLine();

                switch (userChoice)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad0:
                        taskOne.Execute();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        taskTwo.Execute();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        taskThree.ExecuteThree();
                        break;

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        taskThree.ExecuteFour();
                        break;

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        break;

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        return;

                    default:
                        Console.WriteLine("Invalid input, try again...");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}