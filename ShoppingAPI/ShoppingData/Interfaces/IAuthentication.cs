using ShoppingContext.Model;
using ShoppingShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Interfaces
{
    public interface IAuthentication
    {
        Response Login(LoginViewModel model);
        Response LoginWithNewPass(string email,string newPassword);
    }
}
