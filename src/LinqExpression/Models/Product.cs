namespace LinqExpression.Models
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productId">
        /// The unique identifier of the product.
        /// </param>
        /// <param name="productName">
        /// The name of the product.
        /// </param>
        /// <param name="price">
        /// The price of the product.
        /// </param>
        /// <param name="category">
        /// The category of the product.
        /// </param>
        public Product(int productId, string productName, decimal price, string category)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        /// <value>
        /// The unique identifier of the product.
        /// </value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>
        /// The price of the product.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        /// <value>
        /// The category of the product.
        /// </value>
        public string Category { get; set; }
    }
}
