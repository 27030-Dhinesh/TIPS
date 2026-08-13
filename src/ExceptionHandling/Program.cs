using ExceptionHandling.TaskFive;
using ExceptionHandling.TaskFour;
using ExceptionHandling.TaskOne;
using ExceptionHandling.TaskThree;
using ExceptionHandling.TaskTwo;

namespace Assignments
{
    /// <summary>
    /// Entry point of the application.
    /// Presents a menu-driven console interface that allows users to execute
    /// various exception-handling demonstration tasks.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Initializes task runners and displays the main application menu.
        /// Processes user input and routes execution to the selected task.
        /// </summary>
        /// <param name="args">
        /// Command-line arguments supplied to the application.
        /// </param>
        public static void Main(string[] args)
        {
            try
            {
                TaskOneRunner taskOneRunner = new TaskOneRunner();
                TaskTwoRunner taskTwoRunner = new TaskTwoRunner();
                TaskThreeRunner taskThreeRunner = new TaskThreeRunner();
                TaskFourRunner taskFourRunner = new TaskFourRunner();
                TaskFiveRunner taskFiveRunner = new TaskFiveRunner();

                string? choice;
                while (true)
                {
                    Console.Write(@"1. Divide by zero
2. Array access out of bound with custom message
3. Array access out of bound with custom exceptions
4. AppDomain.CurrentDomain.UnhandledException Event
5. Displaying stack trace of Exception
6. Exit

Enter your choice: ");
                    choice = Console.ReadLine();
                    Console.Clear();

                    switch (choice)
                    {
                        case "1":
                            taskOneRunner.Run();
                            break;

                        case "2":
                            taskTwoRunner.Run();
                            break;

                        case "3":
                            taskThreeRunner.Run();
                            break;

                        case "4":
                            taskFourRunner.Run();
                            break;

                        case "5":
                            taskFiveRunner.Run();
                            break;

                        case "6":
                            return;

                        default:
                            Console.WriteLine("Invalid choice, try again.");
                            break;
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: {ex.ToString()}");
            }

            Console.ReadKey();
        }
    }
}