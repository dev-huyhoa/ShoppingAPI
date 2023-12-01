using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategory category;
        private Response res;
        public CategoryController(ICategory _category)
        {
            category = _category;
            res = new Response();
        }
        [HttpGet]
        [Route("listCategory")]
        public object GetCategory()
        {
            res = category.GetCategory();
            return Ok(res);
        }
        [HttpPost]
        [Route("createCategory")]
        public object CreateCategory(CreateUpdateCategoryViewModel model) 
        { 
            res = category.CreateCategory(model);
            return Ok(res);
        }

        [HttpPost]
        [Route("updateCategory")]
        public object UpdateCategory(CreateUpdateCategoryViewModel model)
        {
            res = category.UpdateCategory(model);
            return Ok(res);
        }

        [HttpDelete]
        [Route("deleteCategory")]
        public object DeleteCategory(Guid IdCategory)
        {
            res = category.DeleteCategory(IdCategory);
            return Ok(res);
        }

    }
}
