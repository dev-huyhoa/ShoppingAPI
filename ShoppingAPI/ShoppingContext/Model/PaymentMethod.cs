using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class PaymentMethod
    {
        public int IdPaymentMethod { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }
        public bool Available { get; set; }
        public string Reason { get; set; }
    }
}
