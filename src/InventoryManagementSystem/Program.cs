using InventoryManagementSystem.Repository;
using InventoryManagementSystem.Services;
using static InventoryManagementSystem.ConsoleHelper;

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
            InMemoryStorage productRepository = new InMemoryStorage();
            InventoryManager manager = new InventoryManager(productRepository);

            while (true)
            {
                DisplayAppInfo();
                string choice = GetInput("Enter your choice:", "Invalid input, try again.");

                switch (choice)
                {
                    case "1":
                        HandleProductCreation(manager);
                        break;
                    case "2":
                        HandleProductEdit(manager);
                        break;
                    case "3":
                        HandleProductSearch(manager);
                        break;
                    case "4":
                        HandleProductSearch(manager, true);
                        break;
                    case "5":
                        HandleProductDisplay(manager);
                        break;
                    case "6":
                        HandleProductDeletion(manager);
                        break;
                    case "7":
                        Console.WriteLine("Exiting application...");
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }

        private static void HandleProductCreation(InventoryManager manager)
        {
        }

        private static void HandleProductEdit(InventoryManager manager)
        {
        }

        private static void HandleProductSearch(InventoryManager manager, bool useId = false)
        {
        }

        private static void HandleProductDisplay(InventoryManager manager)
        {
        }

        private static void HandleProductDeletion(InventoryManager manager)
        {
        }
    }
}