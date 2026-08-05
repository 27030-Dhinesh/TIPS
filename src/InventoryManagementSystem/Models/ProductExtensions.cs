using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    /// <summary>
    /// Provides extension methods for working with <see cref="Product"/> instances.
    /// </summary>
    public static class ProductExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="Product"/> instance to a CSV-formatted row.
        /// </summary>
        /// <param name="product">
        /// The product to convert to a CSV row.
        /// </param>
        /// <returns>
        /// A comma-separated string containing the product's identifier, name, price,
        /// and quantity in that order.
        /// </returns>
        public static string ToCSVRow(this Product product)
        {
            return $"{product.Id},{product.Name},{product.Price},{product.Quantity}";
        }

        /// <summary>
        /// Converts the current product instance into a string array representation.
        /// </summary>
        /// <param name="product">
        /// The product to convert to a CSV row.
        /// </param>
        /// <returns>
        /// A string array containing the product's identifier, name, price, and
        /// quantity in that order.
        /// </returns>
        public static string[] ToArray(this Product product)
        {
            return new string[]
            {
                product.Id,
                product.Name,
                product.Price.ToString(),
                product.Quantity.ToString(),
            };
        }
    }
}
