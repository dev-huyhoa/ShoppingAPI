using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public int PaymentMethodId { get; set; }
        public int TotalAmount {  get; set; }
        public int ShippingCharges { get; set; }
        public int AmoutReduced { get; set; }
        public int AmountPaid { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
