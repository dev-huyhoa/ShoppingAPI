using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel.Employee
{
    public class CreateEmpViewModel
    {
        private string nameEmployee;
        private string email;
        private string phone;
        private string image;
        private string address;

        private int roleId;
        private bool status;

        public string NameEmployee { get => nameEmployee; set => nameEmployee = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Image { get => image; set => image = value; }
        public string Address { get => address; set => address = value; }
        public int RoleId { get => roleId; set => roleId = value; }
        public bool Status { get => status; set => status = value; }
    }
}
