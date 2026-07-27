using System.Runtime.CompilerServices;
using InventoryManagementSystem.Models;
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
            string id = GetProductID("Enter the product ID:", "Invalid input for ID, try again.");
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
        }

        private static void HandleProductEdit(InventoryManager manager)
        {
            string oldId = GetProductID("Enter product ID to update:", "Invalid input for id, try again.");
            if (!manager.ContainsProduct(oldId))
            {
                Console.WriteLine($"No product found for id {oldId}.");
                return;
            }

            Console.WriteLine("Edit details:");

            string id = GetProductID("Product ID:", "Invalid input for ID, try again.");
            if (manager.ContainsProduct(id))
            {
                Console.WriteLine($"Product with ID {id} already exists. Switching to main menu.");
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
        }

        private static void HandleProductSearch(InventoryManager manager, bool useId = false)
        {
            if (manager.IsEmpty())
            {
                Console.WriteLine("Inventory is empty, cannot perform search operation.");
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }

            string searchParam;
            if (useId)
            {
                searchParam = GetProductID("Enter product ID to search:", "Invalid input for ID, try again.");
            }
            else
            {
                searchParam = GetProductName("Enter product name to search:", "Invalid input for name, try again.");
            }

            List<Product> searchResult = manager.SearchProduct(searchParam, useId);

            Console.WriteLine("==============================");
            foreach (Product product in searchResult)
            {
                Console.WriteLine(product);
                Console.WriteLine("==============================");
            }

            Thread.Sleep(3000);
            Console.Clear();
        }

        private static void HandleProductDisplay(InventoryManager manager)
        {
            List<Product> products = manager.GetAllProducts();

            if (products.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                Thread.Sleep(1000);
                Console.Clear();
                return;
            }

            Console.WriteLine("==============================");
            foreach (Product product in products)
            {
                Console.WriteLine(product);
                Console.WriteLine("==============================");
            }

            Thread.Sleep(3000);
            Console.Clear();
        }

        private static void HandleProductDeletion(InventoryManager manager)
        {
            if (manager.IsEmpty())
            {
                Console.WriteLine("Inventory is empty; cannot perform deletion operation.");
                Thread.Sleep(1000);
                Console.Clear();
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

            Thread.Sleep(1500);
            Console.Clear();
        }
    }
}