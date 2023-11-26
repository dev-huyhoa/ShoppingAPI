using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class Customer
    {
        public Guid IdCustomer { get; set; }
        public string NameCustomer { get; set; }
        public string Email { get; set; }   
        public string PassWord { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
