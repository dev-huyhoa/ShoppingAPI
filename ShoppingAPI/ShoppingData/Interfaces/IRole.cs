using ShoppingContext.Model;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Interfaces
{
    public interface IRole
    {
        Response GetsRole();
        Response CreateRole(CreateUpdateRoleViewModel input);
        Response UpdateRole(CreateUpdateRoleViewModel input);
        Response DeleteRole(int IdRole);
    }
}
