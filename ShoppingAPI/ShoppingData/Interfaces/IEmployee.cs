using Microsoft.AspNetCore.Http;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Employee;
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
        Response CreateEmployee(CreateEmpViewModel input, ICollection<IFormFile> files);
        Response UpdateEmployee(UpdateEmpViewModel input);
        Response UpdateEmpImage(ICollection<IFormFile> img, UpdateEmpViewModel input);

        Response GetEmployeeById(Guid idEmployee);
        Response DeleteEmployee(Guid idEmployee);

    }
}
