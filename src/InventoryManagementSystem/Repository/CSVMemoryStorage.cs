using System.Runtime.CompilerServices;
using InventoryManagementSystem.Interfaces;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repository
{
    /// <summary>
    /// Implements the IProductRepository contract to provide a CSV file-based storage system.
    /// </summary>
    internal class CSVMemoryStorage : IProductRepository
    {
        private readonly string _fileName;
        private bool _isHeaderSet = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVMemoryStorage"/> class.
        /// </summary>
        /// <param name="fileName">
        /// The path or name of the CSV file used for memory storage.
        /// </param>
        public CSVMemoryStorage(string fileName)
        {
            this._fileName = fileName;
            this.Initialize(fileName);
        }

        /// <inheritdoc/>
        public void Add(Product product)
        {
            using (StreamWriter writer = new StreamWriter(this._fileName, append: true))
            {
                writer.WriteLine(product.ToCSVRow());
            }
        }

        /// <inheritdoc/>
        public bool Contains(string productId)
        {
            List<Product> products = this.GetAll();

            return products.Any(p => p.Id == productId);
        }

        /// <inheritdoc/>
        public bool Delete(string productId)
        {
            List<Product> products = this.GetAll();

            int removeCount = products.RemoveAll(p => p.Id == productId);

            if (removeCount == 0)
            {
                return false;
            }

            this.WriteProductsWithHeader(products);

            return true;
        }

        /// <inheritdoc/>
        public List<Product> GetAll()
        {
            List<Product> products = new ();

            using (StreamReader sr = new StreamReader(this._fileName))
            {
                string line;
                string[] fields;
                Product product;
                sr.ReadLine(); // Skip header row
                while ((line = sr.ReadLine()) is not null)
                {
                    fields = line.Split(",");
                    if (fields.Length == 4)
                    {
                        product = new Product(
                            fields[0],
                            fields[1],
                            decimal.Parse(fields[2]),
                            int.Parse(fields[3]));

                        products.Add(product);
                    }
                }
            }

            return products;
        }

        /// <inheritdoc/>
        public Product? GetOrDefault(string productId)
        {
            return default;
        }

        /// <inheritdoc/>
        public bool IsEmpty()
        {
            using (StreamReader sr = new StreamReader(this._fileName))
            {
                string line;
                sr.ReadLine(); // Skipping the header row
                if ((line = sr.ReadLine()) is null)
                {
                    return true;
                }

                return false;
            }
        }

        /// <inheritdoc/>
        public bool Update(string productId, Product newProduct)
        {
            List<Product> products = this.GetAll();

            Product? product = products.Find(p => p.Id == productId);

            if (product is null)
            {
                return false;
            }

            product.Id = newProduct.Id;
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.Quantity = newProduct.Quantity;

            this.WriteProductsWithHeader(products);

            return true;
        }

        private void Initialize(string fileName)
        {
            if (!File.Exists(fileName))
            {
                // File.Create(fileName) return a FileStream
                using (FileStream fs = File.Create(fileName))
                {
                    // StreamWriter can take both a file path as well
                    // as a Stream
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine("id,name,price,quantity");
                        writer.Flush();
                        this._isHeaderSet = true;
                    }
                }
            }
        }

        private void WriteProductsWithHeader(List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(this._fileName))
            {
                writer.WriteLine("id,name,price,quantity");
                foreach (Product product in products)
                {
                    writer.WriteLine(product.ToCSVRow());
                }
            }
        }
    }
}
