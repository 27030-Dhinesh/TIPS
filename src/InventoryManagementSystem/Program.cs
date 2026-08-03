using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repository;
using InventoryManagementSystem.Services;
using Spectre.Console;
using static System.ConsoleColor;
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
                WriteColorLine("Enter your choice:", Blue);
                string? choice = Console.ReadLine();

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
                        WriteColorLine("Exiting application...", Red);
                        Thread.Sleep(1000);
                        return;
                    default:
                        WriteColorLine("Invalid input for choice, try again.", Red);
                        UICleanup();
                        break;
                }
            }
        }

        private static void HandleProductCreation(InventoryManager manager)
        {
            string? id = GetProductID("Enter the product ID: ", "Invalid input for ID, try again.");
            if (id is null)
            {
                WriteColorLine("Switching to main menu...", Yellow);
                UICleanup();
                return;
            }

            if (manager.ContainsProduct(id))
            {
                WriteColorLine($"Another product with ID {id} exists. Aborting operation...", Red);
                UICleanup(1500);
                return;
            }

            string name = GetProductName("Enter the name of the product: ", "Name is invalid, try again.");
            if (name.Equals(string.Empty))
            {
                WriteColorLine($"Switching to main menu...", Yellow);
                UICleanup(1500);
                return;
            }

            decimal price = GetPrice("Enter the price of the product: ", "Invalid input for price, try again.");
            if (price == 0)
            {
                WriteColorLine($"Switching to main menu...", Yellow);
                UICleanup(1500);
                return;
            }

            int quantity = GetQuantity("Enter the quantity of the product: ", "Invalid input for quantity, try again.");
            if (quantity == 0)
            {
                WriteColorLine($"Switching to main menu...", Yellow);
                UICleanup(1500);
                return;
            }

            Product product = new Product(id, name, price, quantity);

            bool status = manager.AddProduct(product);
            if (status)
            {
                Console.WriteLine("Product added successfully.");
            }
            else
            {
                WriteColorLine("Failed to add product; another product with same ID exists.", Red);
            }

            UICleanup();
        }

        private static void HandleProductEdit(InventoryManager manager)
        {
            if (manager.IsEmpty())
            {
                WriteColorLine("Inventory is empty, cannot perform edit operation.", Red);
                UICleanup();
                return;
            }

            string? oldId = GetProductID("Enter product ID to update: ", "Invalid input for id, try again.");
            if (oldId is null)
            {
                WriteColorLine("Switching to main menu...", Yellow);
                UICleanup();
                return;
            }

            if (!manager.ContainsProduct(oldId))
            {
                WriteColorLine($"No product found for id {oldId}.", Red);
                UICleanup();
                return;
            }

            Console.WriteLine("Edit details:");

            string? newId = GetProductID("Product ID: ", "Invalid input for ID, try again.");
            if (newId is null)
            {
                WriteColorLine("Switching to main menu...", Yellow);
                UICleanup();
                return;
            }

            if (oldId != newId && manager.ContainsProduct(newId))
            {
                WriteColorLine($"Product with ID {newId} already exists. Switching to main menu.", Red);
                UICleanup();
                return;
            }

            string name = GetProductName("Name of the product: ", "Name is invalid, try again.");
            if (name.Equals(string.Empty))
            {
                WriteColorLine($"Switching to main menu...", Yellow);
                UICleanup(1500);
                return;
            }

            decimal price = GetPrice("Price of the product: ", "Invalid input for price, try again.");
            if (price == 0)
            {
                WriteColorLine("Switching to main menu...", Yellow);
                UICleanup(1500);
                return;
            }

            int quantity = GetQuantity("Quantity of the product: ", "Invalid input for quantity, try again.");
            if (quantity == 0)
            {
                WriteColorLine("Switching to main menu...", Yellow);
                UICleanup(1500);
                return;
            }

            Product product = new Product(newId, name, price, quantity);

            if (manager.UpdateProduct(oldId, product))
            {
                Console.WriteLine("Product updation successful.");
            }
            else
            {
                WriteColorLine($"Product updation failed; product with ID {newId} already exists.", Red);
            }

            UICleanup();
        }

        private static void HandleProductSearch(InventoryManager manager, bool useId = false)
        {
            if (manager.IsEmpty())
            {
                WriteColorLine("Inventory is empty, cannot perform search operation.", Red);
                UICleanup();
                return;
            }

            string? searchParam;
            if (useId)
            {
                searchParam = GetProductID("Enter product ID to search: ", "Invalid input for ID, try again.");
                if (searchParam is null)
                {
                    WriteColorLine("Switching to main menu...", Yellow);
                    UICleanup();
                    return;
                }

                if (!manager.ContainsProduct(searchParam))
                {
                    WriteColorLine($"Product with ID {searchParam} not found.", Red);
                    UICleanup();
                    return;
                }
            }
            else
            {
                searchParam = GetProductName("Enter product name to search: ", "Name is invalid, try again.");
                if (searchParam.Equals(string.Empty))
                {
                    WriteColorLine($"Switching to main menu...", Yellow);
                    UICleanup(1500);
                    return;
                }
            }

            List<Product> searchResult = manager.SearchProduct(searchParam, useId);

            if (searchResult.Count == 0)
            {
                WriteColorLine($"No products found for {searchParam}.", Red);
                UICleanup();
                return;
            }

            Table table = PrepareTable(searchResult);
            AnsiConsole.Write(table);

            UICleanup(3000);
        }

        private static void HandleProductDisplay(InventoryManager manager, bool useName = false)
        {
            List<Product> products = manager.GetAllProducts();

            if (products.Count == 0)
            {
                WriteColorLine("Inventory is empty.", Red);
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
                WriteColorLine("Inventory is empty; cannot perform deletion operation.", Red);
                UICleanup();
                return;
            }

            string? id = GetProductID("Enter the product ID to delete: ", "Invalid input for ID, try again.");
            if (id is null)
            {
                WriteColorLine("Switching to main menu...", Yellow);
                UICleanup();
                return;
            }

            if (manager.DeleteProduct(id))
            {
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                WriteColorLine($"Deletion failed, product with ID {id} not found.", Red);
            }

            UICleanup(1500);
        }
    }
}