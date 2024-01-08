using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel
{
    public class CusVMD
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
