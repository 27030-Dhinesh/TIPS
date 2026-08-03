using EmployeeHierarchy.Models;
using EmployeeHierarchy.Services;
using static EmployeeHierarchy.ConsoleOperation;

namespace EmployeeHierarchy
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
            EmployeeService service = new ();

            while (true)
            {
                DisplayAppInfo();
                userChoice = GetInput("Enter your Choice:", "Invalid choice, try again.");

                switch (userChoice)
                {
                    case "1":
                        HandleEmployeeRegistration(service, EmployeeType.Manager);
                        break;
                    case "2":
                        HandleEmployeeRegistration(service, EmployeeType.Developer);
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

        private static void HandleEmployeeRegistration(EmployeeService service, EmployeeType type)
        {
            string name = GetName($"Enter the name of the {type}:", "Invalid name, try again.");
            decimal salary = GetSalary($"Enter the salary of the {type}:", "Invalid input, try again.");

            Employee? employee = service.CreateEmployee(name, salary, type);

            if (employee is Developer developer)
            {
                Console.WriteLine(developer.PrintDetails());
            }
            else if (employee is Manager manager)
            {
                Console.WriteLine(manager.PrintDetails());
            }
            else
            {
                Console.WriteLine("Employee registration failed.");
            }
        }
    }
}