namespace LinqExpression.Models
{
    /// <summary>
    /// Represents an in-memory data context containing sample entities
    /// used for the LINQ exercises.
    /// </summary>
    public class SampleDatabaseContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleDatabaseContext"/> class.
        /// </summary>
        public SampleDatabaseContext()
        {
            this.Products = new List<Product>();
            this.Suppliers = new List<Supplier>();
            this.Orders = new List<Order>();
        }

        /// <summary>
        /// Gets or sets the collection of products.
        /// </summary>
        /// <value>
        /// The collection of products.
        /// </value>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the collection of suppliers.
        /// </summary>
        /// <value>
        /// The collection of suppliers.
        /// </value>
        public List<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Gets or sets the collection of orders.
        /// </summary>
        /// <value>
        /// The collection of orders.
        /// </value>
        public List<Order> Orders { get; set; }
    }
}
