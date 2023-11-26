using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class Category
    {
        public  Guid IdCategory { get; set; } 
        public string Title { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
