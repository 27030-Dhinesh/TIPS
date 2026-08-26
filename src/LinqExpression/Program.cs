using System.Globalization;
using LinqExpression.Models;
using static LinqExpression.Helpers.DataPopulatorHelper;

namespace LinqExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new SampleDatabaseContext();
            context.Products = GetProducts();
            context.Orders = GetOrders();
            context.Suppliers = GetSuppliers();

            var filteredProducts = context.Products
                .Where(product => product.Category.Equals("Electronics", StringComparison.OrdinalIgnoreCase) && product.Price > 5000m)
                .Select(product => new
                {
                    product.ProductName, // SomeOtherName = product.ProductName is valid
                    product.Price,       // and will be accessed using item.SomeOtherName
                });

            var sortedProducts = filteredProducts.OrderByDescending(item => item.Price);

            var averagePrice = sortedProducts.Average(item => item.Price);

            Console.WriteLine(averagePrice);

            var groupedByCategory = context.Products
                .GroupBy(product => product.Category)
                .Select(g => new
                {
                    ProductCategory = g.Key,
                    Count = g.Count(),
                    CostlyProduct = g.MaxBy(groupItem => groupItem.Price),
                });

            foreach (var groupItem in groupedByCategory)
            {
                Console.WriteLine($"{groupItem.ProductCategory}: {groupItem.Count}, {groupItem.CostlyProduct?.ProductName ?? "None"} worth {groupItem.CostlyProduct?.Price}");
            }

            Console.ReadKey();
        }
    }
}