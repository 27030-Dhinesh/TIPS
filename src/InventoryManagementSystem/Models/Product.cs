namespace InventoryManagementSystem.Models
{
    /// <summary>
    /// This is a model class to represent Product items.
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id">ID of the product.</param>
        /// <param name="name">Name of the product.</param>
        /// <param name="price">Price of the product.</param>
        /// <param name="quantity">Quantity of the product.</param>
        public Product(string id, string name, decimal price, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        /// <summary>
        /// Gets or sets the ID of the Product item.
        /// </summary>
        /// <value>The ID of the Product item.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the Product item.
        /// </summary>
        /// <value>Name of the Product item.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the Product item.
        /// </summary>
        /// <value>Price of the Product item.</value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the Product item.
        /// </summary>
        /// <value>Quantity of the Product item.</value>
        public int Quantity { get; set; }
    }
}
