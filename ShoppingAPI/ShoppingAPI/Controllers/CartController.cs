using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Product;

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
        [Authorize]
        [Route("insertCartItem")]
        public IActionResult Create(Guid idCustomer, Guid idProduct)
        {
            var result = cart.InsertCartItem(idCustomer, idProduct);
            return Ok(result ? "Thêm Thành Công" : "Có Lỗi Xảy Ra");
        }
    }
}
