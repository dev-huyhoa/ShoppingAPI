using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart cart;
        private Response res;

        public CartController(ICart _cart)
        {
            cart = _cart;
            res = new Response();
        }

        [HttpPost]
        [Route("insertCartItem")]
        public IActionResult Create(Guid idCustomer, Guid idProduct)
        {
            var result = cart.InsertCartItem(idCustomer, idProduct);
            return Ok(result ? "inserted" : "not inserted");
        }

        [HttpGet]
        [Route("getActiveCartOfUser")]
        public IActionResult GetActiveCartOfUser(Guid idCustomer)
        {
            var result = cart.GetActiveCartOfUser(idCustomer);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllPreviousCartsOfUser")]
        public IActionResult GetAllPreviousCartsOfUser(Guid idCustomer)
        {
            var result = cart.GetAllPreviousCartsOfUser(idCustomer);
            return Ok(result);
        }
    }
}
