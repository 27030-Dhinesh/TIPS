using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExpression.Models
{
    public class SampleDatabaseContext
    {
        public SampleDatabaseContext()
        {
            this.Products = new List<Product>();
            this.Suppliers = new List<Supplier>();
            this.Orders = new List<Order>();
        }

        public List<Product> Products { get; set; }

        public List<Supplier> Suppliers { get; set; }

        public List<Order> Orders { get; set; }
    }
}
