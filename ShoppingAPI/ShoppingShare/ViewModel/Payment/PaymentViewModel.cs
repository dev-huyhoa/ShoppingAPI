using Microsoft.AspNetCore.Mvc;
using ShoppingContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel.Payment
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = new PaymentMethod();
        public CustomerViewModel User { get; set; } = new CustomerViewModel();
        public int TotalAmount { get; set; }
        public int ShipingCharges { get; set; }
        public int AmountReduced { get; set; }
        public int AmountPaid { get; set; }
        public string CreatedAt { get; set; } = null;
    }
}
