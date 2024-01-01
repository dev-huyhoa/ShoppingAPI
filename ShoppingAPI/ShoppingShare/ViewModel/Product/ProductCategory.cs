using ShoppingContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel.Product
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; } = new Category();
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public int Discount { get; set; }

        public int Quantity { get; set; }
        public string ImageName { get; set; } = string.Empty;
    }
}
