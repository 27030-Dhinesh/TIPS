using LinqExpression.Models;

namespace LinqExpression.Tasks
{
    /// <summary>
    /// Task One: Executes a LINQ query that calculates the average price of
    /// high-value electronic products.
    /// </summary>
    public class TaskOne
    {
        private readonly List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskOne"/> class.
        /// </summary>
        /// <param name="products">
        /// The list of products used for demonstrating the LINQ querying
        /// operations.
        /// </param>
        public TaskOne(List<Product> products)
        {
            this._products = products;
        }

        /// <summary>
        /// Execute the actual Task and write the output to the console.
        /// </summary>
        public void Execute()
        {
            decimal averagePrice = this.GetAveragePriceForElectronics();
            Console.WriteLine($"Average Price: {averagePrice}");
        }

        private decimal GetAveragePriceForElectronics()
        {
            var filteredProducts = this._products
                .Where(product => product.Category.Equals("Electronics", StringComparison.OrdinalIgnoreCase) && product.Price > 5000m)
                .Select(product => new
                {
                    product.ProductName, // SomeOtherName = product.ProductName is valid
                    product.Price,       // and will be accessed using item.SomeOtherName
                });

            var sortedProducts = filteredProducts.OrderByDescending(item => item.Price);

            var averagePrice = sortedProducts.Average(item => item.Price);

            return averagePrice;
        }
    }
}
