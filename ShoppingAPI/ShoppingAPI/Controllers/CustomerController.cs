using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using System.Threading.Tasks;
namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomer customer;
        private Response res;

        public CustomerController(ICustomer _customer)
        {
            customer = _customer;
            res = new Response();
        }

        [HttpGet]
        [Route("listCustomer")]
        public object GetsCustomer()
        {
            res = customer.GetCustomer();
            return Ok(res);
        }


        [HttpPost]
        [Route("createCustomer")]
        public object CreateCustomer(CreateCustomerViewModel model)
        {
            res = customer.CreateCustomer(model);
            return Ok(res);
        }

        [HttpPost]
        [Route("updateCustomer")]
        public object UpdateCustomer(CreateCustomerViewModel model)
        {
            res = customer.UpdateCustomer(model);
            return Ok(res);
        }

        [HttpDelete]
        [Route("deleteCustomer")]
        public object DeleteCustomer(Guid IdCustomer)
        {
            res = customer.DeleteCustomer(IdCustomer);
            return Ok(res);
        }
    }
}
