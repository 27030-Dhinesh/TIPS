using EmployeeHierarchy;
using EmployeeHierarchy.Models;
using EmployeeHierarchy.Services;
using static EmployeeHierarchy.ConsoleOperation;

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
            string userChoice;
            EmployeeService service = new ();

            while (true)
            {
                DisplayAppInfo();
                userChoice = GetInput("Enter your Choice:", "Invalid choice, try again.");

                switch (userChoice)
                {
                    case "1":
                        OperateManager(service);
                        break;
                    case "2":
                        OperationDeveloper(service);
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

        private static void OperationDeveloper(EmployeeService service)
        {
            string name = GetName("Enter the name of the Developer:", "Invalid name, try again.");
            decimal salary = GetSalary("Enter the salary of the Developer:", "Invalid input, try again.");

            Employee? employee = service.CreateEmployee(name, salary, EmployeeType.Developer);

            if (employee is Developer developer)
            {
                Console.WriteLine(developer.PrintDetails());
            }
            else
            {
                Console.WriteLine("Developer registration failed.");
            }
        }

        private static void OperateManager(EmployeeService service)
        {
            string name = GetName("Enter the name of the Manager:", "Invalid name, try again.");
            decimal salary = GetSalary("Enter the salary of the Manager:", "Invalid input, try again.");

            Employee? employee = service.CreateEmployee(name, salary, EmployeeType.Manager);

            if (employee is Manager manager)
            {
                Console.WriteLine(manager.PrintDetails());
            }
            else
            {
                Console.WriteLine("Manager registration failed.");
            }
        }
    }
}