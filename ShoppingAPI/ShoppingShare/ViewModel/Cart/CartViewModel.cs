using ShoppingContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel.Cart
{
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public CusVMD Customer { get; set; } = new CusVMD();
        public List<CartItemViewModel> CartItems { get; set; } = new();
        public bool Ordered { get; set; }
        public DateTime OrderedOn { get; set; }
    }
}
