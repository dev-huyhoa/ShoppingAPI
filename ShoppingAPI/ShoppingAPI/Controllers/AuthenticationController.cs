using Microsoft.AspNetCore.Mvc;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private Response res;
        private IAuthentication authentication;
        public AuthenticationController(IAuthentication _authentication)
        {
            authentication = _authentication;
            res = new Response();
        }

        [HttpPost("Login")]
        public object Login(LoginViewModel model)
        {
            res = authentication.Login(model);
            return Ok(res);
        }
    }
}
