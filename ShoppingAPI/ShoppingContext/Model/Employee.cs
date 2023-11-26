using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingContext.Model
{
    public class Employee
    {
        public Guid IdEmployee { get; set; }
        public string NameEmployee { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
