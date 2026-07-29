using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using InventoryManagementSystem.Services;
using Spectre.Console;
using static InventoryManagementSystem.ColorConstants;
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
                string choice = GetInput("Enter your choice: ", "Invalid input for choice, try again.");

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
                        WriteColorLine("Exiting application...", RED);
                        Thread.Sleep(1000);
                        return;
                    default:
                        WriteColorLine("Invalid input for choice, try again.", RED);
                        UICleanup();
                        break;
                }
            }
        }

        private static void HandleProductCreation(InventoryManager manager)
        {
            string id = GetProductID("Enter the product ID: ", "Invalid input for ID, try again.");
            if (manager.ContainsProduct(id))
            {
                WriteColorLine($"Another product with ID {id} exists. Aborting operation...", RED);
                UICleanup(1500);
                return;
            }

            string name = GetProductName("Enter the name of the product: ", "Invalid input for Name, try again.");
            decimal price = GetPrice("Enter the price of the product: ", "Invalid input for price, try again.");
            int quantity = GetQuantity("Enter the quantity of the product: ", "Invalid input for quantity, try again.");

            Product product = new Product(id, name, price, quantity);

            bool status = manager.AddProduct(product);
            if (status)
            {
                Console.WriteLine("Product added successfully.");
            }
            else
            {
                WriteColorLine("Failed to add product; another product with same ID exists.", RED);
            }

            UICleanup();
        }

        private static void HandleProductEdit(InventoryManager manager)
        {
            if (manager.IsEmpty())
            {
                WriteColorLine("Inventory is empty, cannot perform edit operation.", RED);
                UICleanup();
                return;
            }

            string oldId = GetProductID("Enter product ID to update: ", "Invalid input for id, try again.");
            if (!manager.ContainsProduct(oldId))
            {
                WriteColorLine($"No product found for id {oldId}.", RED);
                UICleanup();
                return;
            }

            Console.WriteLine("Edit details:");

            string newId = GetProductID("Product ID: ", "Invalid input for ID, try again.");
            if (oldId != newId && manager.ContainsProduct(newId))
            {
                WriteColorLine($"Product with ID {newId} already exists. Switching to main menu.", RED);
                UICleanup();
                return;
            }

            string name = GetProductName("Name of the product: ", "Invalid input for Name, try again.");
            decimal price = GetPrice("Price of the product: ", "Invalid input for price, try again.");
            int quantity = GetQuantity("Quantity of the product: ", "Invalid input for quantity, try again.");

            Product product = new Product(newId, name, price, quantity);

            if (manager.UpdateProduct(oldId, product))
            {
                Console.WriteLine("Product updation successful.");
            }
            else
            {
                WriteColorLine($"Product updation failed; product with ID {newId} already exists.", RED);
            }

            UICleanup();
        }

        private static void HandleProductSearch(InventoryManager manager, bool useId = false)
        {
            if (manager.IsEmpty())
            {
                WriteColorLine("Inventory is empty, cannot perform search operation.", RED);
                UICleanup();
                return;
            }

            string searchParam;
            if (useId)
            {
                searchParam = GetProductID("Enter product ID to search: ", "Invalid input for ID, try again.");
                if (!manager.ContainsProduct(searchParam))
                {
                    WriteColorLine($"Product with ID {searchParam} not found.", RED);
                    UICleanup();
                    return;
                }
            }
            else
            {
                searchParam = GetProductName("Enter product name to search: ", "Invalid input for name, try again.");
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
                WriteColorLine("Inventory is empty.", RED);
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
                WriteColorLine("Inventory is empty; cannot perform deletion operation.", RED);
                UICleanup();
                return;
            }

            string id = GetProductID("Enter the product ID to delete: ", "Invalid input for ID, try again.");
            if (manager.DeleteProduct(id))
            {
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                WriteColorLine($"Deletion failed, product with ID {id} not found.", RED);
            }

            UICleanup(1500);
        }

        private static void UICleanup(int ms = 1000)
        {
            Thread.Sleep(ms);
            Console.Clear();
        }

        private static void WriteColorLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}