using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqExpression.Models;

namespace LinqExpression.Helpers
{
    public static class DataPopulatorHelper
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product(1, "Laptop", 75000m, "Electronics"),
                new Product(2, "Mobile Phone", 35000m, "Electronics"),
                new Product(3, "Smart Watch", 12000m, "Electronics"),
                new Product(4, "Headphones", 2500m, "Electronics"),

                new Product(5, "Office Chair", 8500m, "Furniture"),
                new Product(6, "Study Table", 15000m, "Furniture"),
                new Product(7, "Bookshelf", 7000m, "Furniture"),

                new Product(8, "Notebook", 120m, "Stationery"),
                new Product(9, "Pen Pack", 250m, "Stationery"),
                new Product(10, "Marker Set", 450m, "Stationery"),

                new Product(11, "Water Bottle", 600m, "Accessories"),
                new Product(12, "Backpack", 1800m, "Accessories"),
                new Product(13, "Travel Bag", 3200m, "Accessories"),

                new Product(14, "Coffee Maker", 4500m, "Home Appliances"),
                new Product(15, "Mixer Grinder", 5200m, "Home Appliances"),
                new Product(16, "Microwave Oven", 11000m, "Home Appliances"),

                new Product(17, "Keyboard", 1200m, "Electronics"),
                new Product(18, "Mouse", 800m, "Electronics"),
                new Product(19, "Gaming Monitor", 22000m, "Electronics"),
                new Product(20, "Printer", 9500m, "Electronics"),
            };
        }

        public static List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order(1, new DateTime(2025, 1, 15), "Pending"),
                new Order(2, new DateTime(2025, 1, 18), "Shipped"),
                new Order(3, new DateTime(2025, 1, 20), "Delivered"),
                new Order(4, new DateTime(2025, 2, 5), "Cancelled"),
                new Order(5, new DateTime(2025, 2, 10), "Pending"),
                new Order(6, new DateTime(2025, 2, 15), "Shipped"),
                new Order(7, new DateTime(2025, 3, 1), "Delivered"),
                new Order(8, new DateTime(2025, 3, 12), "Pending"),
                new Order(9, new DateTime(2025, 3, 25), "Delivered"),
                new Order(10, new DateTime(2025, 4, 8), "Cancelled"),
                new Order(11, new DateTime(2025, 4, 15), "Shipped"),
                new Order(12, new DateTime(2025, 4, 22), "Delivered"),
                new Order(13, new DateTime(2025, 5, 3), "Pending"),
                new Order(14, new DateTime(2025, 5, 10), "Shipped"),
                new Order(15, new DateTime(2025, 5, 20), "Delivered"),
                new Order(16, new DateTime(2025, 6, 5), "Cancelled"),
                new Order(17, new DateTime(2025, 6, 15), "Pending"),
                new Order(18, new DateTime(2025, 6, 25), "Delivered"),
                new Order(19, new DateTime(2025, 7, 10), "Shipped"),
                new Order(20, new DateTime(2025, 7, 18), "Delivered"),
            };
        }

        public static List<Supplier> GetSuppliers()
        {
            return new List<Supplier>
            {
                new Supplier(1, "TechSource Ltd", 1),
                new Supplier(2, "Global Electronics", 1),
                new Supplier(3, "Mobile Hub", 2),
                new Supplier(4, "TechSource Ltd", 2),
                new Supplier(5, "Smart Devices Inc", 3),
                new Supplier(6, "Audio World", 4),

                new Supplier(7, "Furniture House", 5),
                new Supplier(8, "Furniture House", 6),
                new Supplier(9, "WoodWorks", 7),

                new Supplier(10, "Office Supplies Co", 8),
                new Supplier(11, "Office Supplies Co", 9),
                new Supplier(12, "Office Supplies Co", 10),

                new Supplier(13, "Lifestyle Traders", 11),
                new Supplier(14, "Lifestyle Traders", 12),
                new Supplier(15, "Travel Essentials", 13),

                new Supplier(16, "Home Appliances Co", 14),
                new Supplier(17, "Home Appliances Co", 15),
                new Supplier(18, "Kitchen Experts", 16),

                new Supplier(19, "Peripherals Plus", 17),
                new Supplier(20, "Peripherals Plus", 18),
                new Supplier(21, "Gaming Gear", 19),
                new Supplier(22, "Office Tech", 20),

                new Supplier(23, "Global Electronics", 19),
                new Supplier(24, "TechSource Ltd", 20),
            };
        }
    }
}
