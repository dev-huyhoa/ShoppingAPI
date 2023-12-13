using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class Size
    {
        public int IdSize { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<ProductSize> ProductSizeColors { get; set; }
    }
}
