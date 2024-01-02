using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Employee;
using ShoppingShare.ViewModel.Product;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct product;
        private Response res;

        public ProductController(IProduct _product)
        {
            product = _product;
            res = new Response();
        }

        [HttpPost]
        [Authorize]
        [Route("createProduct")]
        public object Create([FromForm] ICollection<IFormFile> file)
        {
            var modelData = Request.Form["resProductData"];
            ProductViewModel model = JsonConvert.DeserializeObject<ProductViewModel>(modelData);

            res = product.CreateProduct(model, file);
            return Ok(res);
        }

        [HttpPost]
        [Authorize]
        [Route("updateProductImg")]
        public object updateProductImg([FromForm] ICollection<IFormFile> file)
        {
            var modelData = Request.Form["resProductData"];
            ProductViewModel model = JsonConvert.DeserializeObject<ProductViewModel>(modelData);

            res = product.UpdateProductImg(model, file);
            return Ok(res);
        }

        [HttpGet]
        [Route("getProduct")]
        public object GetProductDetail()
        {
            res = product.GetProduct();
            return Ok(res);
        }

        [HttpGet]
        [Route("getProductImg")]
        public object getProductImg(Guid idProduct)
        {
            res = product.GetProductImg(idProduct);
            return Ok(res);
        }

        [HttpDelete]
        [Route("deleteProduct")]
        public object Delete(Guid idProduct)
        {
            res = product.DeleteProduct(idProduct);
            return Ok(res);
        }

        #region Cus
        [HttpGet]
        [Route("getProductCategories")]
        public IActionResult GetProductCategories(int idCategory)
        {
            var result = product.GetProductCategories(idCategory);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProductById")]
        public IActionResult GetProductById(Guid id)
        {
            var result = product.GetProductById(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProductByIdCate")]
        public IActionResult GetProductByIdCate(int idCate)
        {
            var result = product.GetProducts(idCate);
            return Ok(result);
        }
        #endregion
    }
}
