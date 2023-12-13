using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class ProductImage
    {
        public Guid IdProductImage { get; set; }
        public Guid ProductId { get; set; }
        public string imageUrl { get; set; }
        public Product Product { get; set; }
        public bool IsDelete { get; set; }
    }
}
