using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Interfaces
{
    public interface IEmployee
    {
        Response GetsEmployee();
        Response CreateEmployee(CreateUpdateEmpViewModel input);
        Response UpdateEmployee(CreateUpdateEmpViewModel input);
    }
}
