using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Employee;

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
        public object Create([FromForm] ICollection<IFormFile> file)
        {
            var modelData = Request.Form["resEmployeeData"];
            CreateEmpViewModel model = JsonConvert.DeserializeObject<CreateEmpViewModel>(modelData);
            res = employee.CreateEmployee(model, file);
            return Ok(res);
        }

        [HttpPost]
        [Route("updateEmpImg")]
        public object UpdateEmpImage([FromForm] ICollection<IFormFile> file)
        {
            var modelData = Request.Form["resEmployeeData"];
            UpdateEmpViewModel model = JsonConvert.DeserializeObject<UpdateEmpViewModel>(modelData);
            res = employee.UpdateEmpImage(file, model);
            return Ok(res);
        }

        [HttpPost]
        [Route("updateEmployee")]
        public object UpdateEmployee(UpdateEmpViewModel model)
        {
            res = employee.UpdateEmployee(model);
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

        [HttpPost]
        [Route("changePassEmp")]
        public object ChangePassEmpUseOTP(Guid idEmployee, string password)
        {
            res = employee.ChangePassEmp(idEmployee, password);
            return Ok(res);
        }

        [HttpPost]
        [Route("SendPassEmp")]
        public object SendPassEmp(string email, string subject)
        {
            res = employee.SendPassEmp(email, subject);
            return Ok(res);
        }


        [HttpPost]
        [Route("ChangePassEmpUseOTP")]
        public object ChangePassEmpUseOTP(string email, string newPassword, string otp)
        {
            res = employee.ChangePassEmpUseOTP(email, newPassword, otp);
            return Ok(res);
        }
    }
}
