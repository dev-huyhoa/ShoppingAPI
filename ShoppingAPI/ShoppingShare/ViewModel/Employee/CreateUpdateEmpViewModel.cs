using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel.Customer
{
    public class CreateUpdateEmpViewModel
    {
        public Guid IdEmployee { get; set; }
        public string NameEmployee { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public int RoleId { get; set; }
        public bool Status { get; set; }
    }
}
