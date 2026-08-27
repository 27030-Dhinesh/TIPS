namespace LinqExpression.Models
{
    /// <summary>
    /// Represents a supplier.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        /// <param name="supplierId">
        /// The unique identifier of the supplier.
        /// </param>
        /// <param name="supplierName">
        /// The name of the supplier.
        /// </param>
        /// <param name="productId">
        /// The unique identifier of the product supplied by the supplier.
        /// </param>
        public Supplier(int supplierId, string supplierName, int productId)
        {
            this.SupplierId = supplierId;
            this.SupplierName = supplierName;
            this.ProductId = productId;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the supplier.
        /// </summary>
        /// <value>
        /// The unique identifier of the supplier.
        /// </value>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        /// <value>
        /// The name of the supplier.
        /// </value>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the product supplied by the supplier.
        /// </summary>
        /// <value>
        /// The unique identifier of the product supplied by the supplier.
        /// </value>
        public int ProductId { get; set; }
    }
}
