using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class Order
    {
        public Guid IdOrder { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public decimal ShippingFee { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
