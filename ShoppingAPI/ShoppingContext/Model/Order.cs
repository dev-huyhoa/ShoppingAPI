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
        public decimal Total { get; set; } = 0;
        public DateTime CreateAt { get; set; }
        public int IdPayment { get; set; }
        public Guid CartId { get; set; }
        public bool IsDelete { get; set; }

    }
}
