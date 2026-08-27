using LinqExpression.Models;

namespace LinqExpression.Tasks
{
    /// <summary>
    /// Task Two: Demonstrates LINQ grouping and join operations on product and
    /// supplier data.
    /// </summary>
    public class TaskTwo
    {
        private readonly List<Product> _products;
        private readonly List<Supplier> _suppliers;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskTwo"/> class.
        /// </summary>
        /// <param name="products">
        /// The list of products used for demonstrating the LINQ querying
        /// operations.</param>
        /// <param name="suppliers">
        /// The list of suppliers used for demonstrating the LINQ querying
        /// operations.
        /// </param>
        public TaskTwo(List<Product> products, List<Supplier> suppliers)
        {
            this._products = products;
            this._suppliers = suppliers;
        }

        /// <summary>
        /// Execute the actual Task and write the output to the console.
        /// </summary>
        public void Execute()
        {
            this.GroupingSubTask();
            Console.WriteLine();
            this.InnerJoinSubTask();
        }

        private void InnerJoinSubTask()
        {
            var innerJoinResult = this._products
                            .Join(
                                this._suppliers,
                                product => product.ProductId,
                                supplier => supplier.ProductId,
                                (product, supplier) => new
                                {
                                    product.ProductName,
                                    supplier.SupplierName,
                                });

            Console.WriteLine("JOIN subtask result:");
            foreach (var item in innerJoinResult)
            {
                Console.WriteLine($"{item.ProductName,-15}: {item.SupplierName}");
            }
        }

        private void GroupingSubTask()
        {
            var productsCategoryGroup = this._products
                            .GroupBy(product => product.Category)
                            .Select(g => new
                            {
                                ProductCategory = g.Key,
                                Count = g.Count(),
                                ExpensiveProduct = g.MaxBy(groupItem => groupItem.Price),
                            });

            Console.WriteLine("Grouping LINQ task result:");
            foreach (var groupItem in productsCategoryGroup)
            {
                if (groupItem.ExpensiveProduct is null)
                {
                    continue;
                }

                Console.WriteLine($"{groupItem.ProductCategory}: {groupItem.Count}, {groupItem.ExpensiveProduct.ProductName} worth {groupItem.ExpensiveProduct.Price}");
            }
        }
    }
}
