using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingShare.ViewModel.Role
{
    public class CreateUpdateRoleViewModel
    {
        public int IdRole { get; set; }
        public string NameRole { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public bool Status { get; set; }
    }
}
