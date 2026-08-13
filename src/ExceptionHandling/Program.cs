using ExceptionHandling.TaskFive;
using ExceptionHandling.TaskFour;
using ExceptionHandling.TaskOne;
using ExceptionHandling.TaskThree;
using ExceptionHandling.TaskTwo;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
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
4. 
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
    }
}