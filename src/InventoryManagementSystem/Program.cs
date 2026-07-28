using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using InventoryManagementSystem.Services;
using Spectre.Console;
using static InventoryManagementSystem.ConsoleHelper;

namespace InventoryManagementSystem
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
                        HandleProductDisplay(manager, true);
                        break;
                    case "7":
                        HandleProductDeletion(manager);
                        break;
                    case "8":
                        Console.WriteLine("Exiting application...");
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.WriteLine("Invalid input, try again.");
                        UICleanup();
                        break;
                }
            }
        }

        private static void HandleProductCreation(InventoryManager manager)
        {
            string id = GetProductID("Enter the product ID:", "Invalid input for ID, try again.");
            if (manager.ContainsProduct(id))
            {
                Console.WriteLine($"Another product with ID {id} exists. Aborting operation...");
                UICleanup(1500);
                return;
            }

            string name = GetProductName("Enter the name of the product:", "Invalid input for Name, try again.");
            decimal price = GetPrice("Enter the price of the product:", "Invalid input for price, try again.");
            int quantity = GetQuantity("Enter the quantity of the product:", "Invalid input for quantity, try again.");

            Product product = new Product(id, name, price, quantity);

            bool status = manager.AddProduct(product);
            if (status)
            {
                Console.WriteLine("Product added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add product; another product with same ID exists.");
            }

            UICleanup();
        }

        private static void HandleProductEdit(InventoryManager manager)
        {
            if (manager.IsEmpty())
            {
                Console.WriteLine("Inventory is empty, cannot perform edit operation.");
                UICleanup();
                return;
            }

            string oldId = GetProductID("Enter product ID to update:", "Invalid input for id, try again.");
            if (!manager.ContainsProduct(oldId))
            {
                Console.WriteLine($"No product found for id {oldId}.");
                UICleanup();
                return;
            }

            Console.WriteLine("Edit details:");

            string id = GetProductID("Product ID:", "Invalid input for ID, try again.");
            if (manager.ContainsProduct(id))
            {
                Console.WriteLine($"Product with ID {id} already exists. Switching to main menu.");
                UICleanup();
                return;
            }

            string name = GetProductName("Name of the product:", "Invalid input for Name, try again.");
            decimal price = GetPrice("Price of the product:", "Invalid input for price, try again.");
            int quantity = GetQuantity("Quantity of the product:", "Invalid input for quantity, try again.");

            Product product = new Product(id, name, price, quantity);

            if (manager.UpdateProduct(oldId, product))
            {
                Console.WriteLine("Product updation successful.");
            }
            else
            {
                Console.WriteLine($"Product updation failed; product with ID {id} already exists.");
            }

            UICleanup();
        }

        private static void HandleProductSearch(InventoryManager manager, bool useId = false)
        {
            if (manager.IsEmpty())
            {
                Console.WriteLine("Inventory is empty, cannot perform search operation.");
                UICleanup();
                return;
            }

            string searchParam;
            if (useId)
            {
                searchParam = GetProductID("Enter product ID to search:", "Invalid input for ID, try again.");
                if (!manager.ContainsProduct(searchParam))
                {
                    Console.WriteLine($"Product with ID {searchParam} not found.");
                    UICleanup();
                    return;
                }
            }
            else
            {
                searchParam = GetProductName("Enter product name to search:", "Invalid input for name, try again.");
            }

            List<Product> searchResult = manager.SearchProduct(searchParam, useId);

            Table table = PrepareTable(searchResult);
            AnsiConsole.Write(table);

            UICleanup(3000);
        }

        private static void HandleProductDisplay(InventoryManager manager, bool useName = false)
        {
            List<Product> products = manager.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                UICleanup();
                return;
            }

            products = products.OrderBy(prod => useName ? prod.Name : prod.Id).ToList();

            Table table = PrepareTable(products);
            AnsiConsole.Write(table);

            UICleanup(3000);
        }

        private static void HandleProductDeletion(InventoryManager manager)
        {
            if (manager.IsEmpty())
            {
                Console.WriteLine("Inventory is empty; cannot perform deletion operation.");
                UICleanup();
                return;
            }

            string id = GetProductID("Enter the product ID to delete:", "Invalid input for ID, try again.");
            if (manager.DeleteProduct(id))
            {
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Deletion failed, product with ID {id} not found.");
            }

            UICleanup(1500);
        }

        private static void UICleanup(int ms = 1000)
        {
            Thread.Sleep(ms);
            Console.Clear();
        }
    }
}