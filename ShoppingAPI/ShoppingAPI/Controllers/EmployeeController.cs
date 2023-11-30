using Microsoft.AspNetCore.Mvc;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Customer;

namespace ShoppingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployee employee;
        private Response res;

        public EmployeeController(IEmployee _employee)
        {
            employee = _employee;
            res = new Response();
        }

        [HttpGet]
        [Route("listEmployee")]
        public object Get()
        {
            res = employee.GetsEmployee();
            return Ok(res);
        }

        [HttpPost]
        [Route("createEmployee")]
        public object Create(CreateUpdateEmpViewModel model)
        {
            res = employee.CreateEmployee(model);
            return Ok(res);
        }

        [HttpPost]
        [Route("updateEmployee")]
        public object UpdateEmployee([FromForm] IFormFile file)
        {
            //res = employee.UpdateEmployee(model);
            return Ok(res);
        }

        [HttpGet]
        [Route("getEmployeeById")]
        public object GetEmployeeById(Guid idEmployee)
        {
            res = employee.GetEmployeeById(idEmployee);
            return Ok(res);
        }

        [HttpDelete]
        [Route("deleteEmployee")]
        public object Delete(Guid idEmployee)
        {
            res = employee.DeleteEmployee(idEmployee);
            return Ok(res);
        }
    }
}
