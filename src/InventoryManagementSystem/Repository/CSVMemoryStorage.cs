using InventoryManagementSystem.Interfaces;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repository
{
    /// <summary>
    /// Implements the IProductRepository contract to provide a CSV file-based storage system.
    /// </summary>
    internal class CSVMemoryStorage : IProductRepository
    {
        /// <inheritdoc/>
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Contains(string productId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Delete(string productId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Product? GetOrDefault(string productId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Update(string productId, Product newProduct)
        {
            throw new NotImplementedException();
        }
    }
}
