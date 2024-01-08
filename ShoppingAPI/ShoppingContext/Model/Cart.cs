using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class Cart
    {
        public Guid IdCart { get; set; } 
        public DateTime OrderedOn { get; set; }
        public Guid CustomerId { get;set; }
        public bool Ordered { get; set; }
        public bool IsDelete { get; set; }

    }
}
