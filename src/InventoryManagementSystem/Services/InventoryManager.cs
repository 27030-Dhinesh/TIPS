using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    /// <summary>
    /// Provides business logic and data management for products.
    /// </summary>
    internal class InventoryManager
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryManager"/> class.
        /// </summary>
        /// <param name="productRepository">The storage system that the Inventory Management system will use.</param>
        public InventoryManager(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        /// <summary>
        /// Check whether the repository is empty or not.
        /// </summary>
        /// <returns>True if the repository is empty, false otherwise.</returns>
        public bool IsEmpty()
        {
            return this._productRepository.IsEmpty();
        }

        /// <summary>
        /// Inserts a new product into the storage system.
        /// </summary>
        /// <param name="product">The product to add to the repository.</param>
        /// <returns>True if product added successfully, false otherwise.</returns>
        public bool AddProduct(Product product)
        {
            try
            {
                this._productRepository.Add(product);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates a product info using the product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to update.</param>
        /// <param name="product">Product item with the updated info.</param>
        /// <returns>True if updation successful, false otherwise.</returns>
        public bool UpdateProduct(string productId, Product product)
        {
            return this._productRepository.Update(productId, product);
        }

        /// <summary>
        /// Deletes a product from the storage system using the product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to delete from the storage system.</param>
        /// <returns>True if deletion successful, false otherwise.</returns>
        public bool DeleteProduct(string productId)
        {
            return this._productRepository.Delete(productId);
        }

        /// <summary>
        /// Searches the product collection for matches based on either the product ID or name.
        /// </summary>
        /// <param name="searchParam">The search term to match against (a specific ID or product name).</param>
        /// <param name="isId">
        /// Set to <see langword="true"/> to search by product ID;
        /// set to <see langword="false"/> to search by product name. The default is <see langword="false"/>.</param>
        /// <returns>A <see cref="List{Product}"/> containing all matching products, or an empty list if no matches are found.</returns>
        public List<Product> SearchProduct(string searchParam, bool isId = false)
        {
            List<Product> products = this.GetAllProducts();
            List<Product> searchResult = new ();

            if (isId)
            {
                foreach (Product prod in products)
                {
                    if (searchParam.Equals(prod.Id))
                    {
                        searchResult.Add(prod);
                    }
                }
            }
            else
            {
                foreach (Product prod in products)
                {
                    if (searchParam.Contains(prod.Name, StringComparison.OrdinalIgnoreCase)) ;
                    {
                        searchResult.Add(prod);
                    }
                }
            }

            return searchResult;
        }

        /// <summary>
        /// Retrieves all products from the storage system.
        /// </summary>
        /// <returns>List of all products from the storage system.</returns>
        public List<Product> GetAllProducts()
        {
            return this._productRepository.GetAll();
        }

        /// <summary>
        /// Retrieves product using product ID from the storage system.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product from the repository matching the given ID if found, null otherwise.</returns>
        public Product? GetProductOrDefault(string productId)
        {
            return this._productRepository.GetOrDefault(productId);
        }

        /// <summary>
        /// Check whether the product is available or not using its product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to search for.</param>
        /// <returns>True if the product is stored in the repository, false otherwise.</returns>
        public bool ContainsProduct(string productId)
        {
            return this._productRepository.Contains(productId);
        }
    }
}
