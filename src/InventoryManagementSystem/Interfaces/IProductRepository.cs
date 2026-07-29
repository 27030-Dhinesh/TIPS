using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Interfaces
{
    /// <summary>
    /// Defines the standard contract for a Product repository.
    /// </summary>
    internal interface IProductRepository
    {
        /// <summary>
        /// Check whether the repository is empty or not.
        /// </summary>
        /// <returns>True if the repository is empty, false otherwise.</returns>
        bool IsEmpty();

        /// <summary>
        /// Inserts a new product into the storage system.
        /// </summary>
        /// <param name="product">The product to add to the repository.</param>
        void Add(Product product);

        /// <summary>
        /// Updates a product info using the product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="newProduct">Product item with the updated info.</param>
        /// <returns>True if updation successful, false otherwise.</returns>
        bool Update(string productId, Product newProduct);

        /// <summary>
        /// Deletes a product from the storage system using the product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete from the storage system.</param>
        /// <returns>True if deletion successful, false otherwise.</returns>
        bool Delete(string productId);

        /// <summary>
        /// Retrieves all products from the storage system.
        /// </summary>
        /// <returns>List of all products from the storage system.</returns>
        List<Product> GetAll();

        /// <summary>
        /// Retrieves product using product ID from the storage system.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product from the repository matching the given ID if found, null otherwise.</returns>
        Product? GetOrDefault(string productId);

        /// <summary>
        /// Check whether the product is available or not using its product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to search for.</param>
        /// <returns>True if the product is stored in the repository, false otherwise.</returns>
        bool Contains(string productId);
    }
}
