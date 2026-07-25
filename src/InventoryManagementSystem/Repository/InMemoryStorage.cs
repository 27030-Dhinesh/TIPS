using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repository
{
    /// <summary>
    /// Implements the IProductRepository contract to provide an in-memory storage system.
    /// </summary>
    internal class InMemoryStorage : IProductRepository
    {
        private readonly Dictionary<string, Product> _products;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryStorage"/> class.
        /// </summary>
        public InMemoryStorage()
        {
            this._products = new Dictionary<string, Product>();
        }

        /// <inheritdoc/>
        public bool IsEmpty()
        {
            return this._products.Count == 0;
        }

        /// <inheritdoc/>
        public void Add(Product product)
        {
            try
            {
                this._products.Add(product.Id, product);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Another product with ID {product.Id} already exists.", ex);
            }
        }

        /// <inheritdoc/>
        public bool Update(string productId, Product newProduct)
        {
            return true;
        }

        /// <inheritdoc/>
        public bool Delete(string productId)
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Cannot delete product from empty inventory.");
            }

            if (!this.Contains(productId))
            {
                throw new 
            }
        }

        /// <inheritdoc/>
        public List<Product> GetAll()
        {

            return this._products.Values.ToList();
        }

        /// <inheritdoc/>
        public Product? GetOrDefault(string productId)
        {
            return this._products.GetValueOrDefault(productId);
        }

        /// <inheritdoc/>
        public bool Contains(string productId)
        {
            return this._products.ContainsKey(productId);
        }
    }
}
