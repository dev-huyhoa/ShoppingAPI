using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class CartItem
    {
        public Guid CartItemId { get; set; }
        public Guid IdCart { get; set; }
        public Guid ProductId { get; set; }
    }
}
