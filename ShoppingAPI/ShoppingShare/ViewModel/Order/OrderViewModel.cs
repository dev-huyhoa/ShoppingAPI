using ShoppingContext.Model;
using ShoppingShare.ViewModel.Cart;
using ShoppingShare.ViewModel.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public CusVMD User { get; set; }
        public CartViewModel Cart { get; set; }
        public PaymentViewModel Payment { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
