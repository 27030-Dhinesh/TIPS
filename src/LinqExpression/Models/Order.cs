namespace LinqExpression.Models
{
    /// <summary>
    /// Represents a customer order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="orderId">
        /// The unique identifier of the order.
        /// </param>
        /// <param name="orderDate">
        /// The date on which the order was placed.
        /// </param>
        /// <param name="orderStatus">
        /// The current status of the order.
        /// </param>
        public Order(int orderId, DateTime orderDate, string orderStatus)
        {
            this.OrderId = orderId;
            this.OrderDate = orderDate;
            this.OrderStatus = orderStatus;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the order.
        /// </summary>
        /// <value>
        /// The unique identifier of the order.
        /// </value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the date on which the order was placed.
        /// </summary>
        /// <value>
        /// The date on which the order was placed.
        /// </value>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the current status of the order.
        /// </summary>
        /// <value>
        /// The current status of the order.
        /// </value>
        public string OrderStatus { get; set; }
    }
}
