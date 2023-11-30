using ShoppingContext.Model;
using ShoppingShare.ViewModel;
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
        Response CreateRole(Role input);
        Response UpdateRole(Role input);
        Response DeleteRole(int IdRole);
    }
}
