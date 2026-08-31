using LinqExpression.Models;

namespace LinqExpression.Tasks
{
    /// <summary>
    /// Task Five: Use and demonstrate the custom Query Builder on the
    /// products data collection from the database context.
    /// </summary>
    public class TaskFive
    {
        private readonly List<Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskFive"/> class.
        /// </summary>
        /// <param name="products">
        /// The list of products used for demonstrating custom LINQ
        /// Query Builder.
        /// </param>
        public TaskFive(List<Product> products)
        {
            this._products = products;
        }

        /// <summary>
        /// Execute the actual Task and write the output to the console.
        /// </summary>
        public void Execute()
        {
            List<Product> result = new QueryBuilder<Product>(this._products)
                .Filter(p => p.Price > 5000)
                .SortBy(p => p.Price, descending: true)
                .Execute();

            foreach (var product in result)
            {
                Console.WriteLine($"{product.ProductId}, {product.ProductName}, {product.Price}");
            }
        }
    }
}
