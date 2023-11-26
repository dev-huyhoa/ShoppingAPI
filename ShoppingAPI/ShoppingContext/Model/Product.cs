using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class Product
    {
        public Guid IdProduct { get; set; } 
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public int StockQuantity { get; set; }
        public string Description { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsNewArrival { get; set; }
        public bool IsSale { get; set; }
        public bool IsDelete { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ProductSizeColor> ProductSizeColors { get; set; }
    }
}
