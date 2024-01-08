using ShoppingShare.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel.Cart
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public ProductCategory Product { get; set; } = new ProductCategory();
    }
}
