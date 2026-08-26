using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExpression.Models
{
    public class Order
    {
        public Order(int orderId, DateTime orderDate, string orderStatus)
        {
            this.OrderId = orderId;
            this.OrderDate = orderDate;
            this.OrderStatus = orderStatus;
        }

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }
    }
}
