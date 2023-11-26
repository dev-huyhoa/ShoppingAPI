using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class OrderDetail
    {
        public Guid IdOrderDetail { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public bool IsDelete { get; set; }
        
    }
}
