using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel
{
    public class Authentication
    {
        public string Token { get; set; }
        public string RefToken { get; set; }
        public int RoleId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
    }
}
