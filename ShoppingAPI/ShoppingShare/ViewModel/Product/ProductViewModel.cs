using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel.Product
{
    public class ProductViewModel
    {
        public Guid IdProduct { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public string Description { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsNewArrival { get; set; }
        public bool IsSale { get; set; }
        public Guid CategoryId { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public int IdSize { get; set; }
        public bool IsDelete { get; set; }
    }
}
