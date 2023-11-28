using Microsoft.AspNetCore.Mvc;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private IRole role;
        private Response res;

        public RoleController(IRole _role)
        {
            role = _role;
            res = new Response();
        }

        [HttpGet]
        [Route("listRole")]
        public object Get()
        {
            res = role.GetsRole();
            return Ok(res);
        }
    }
}
