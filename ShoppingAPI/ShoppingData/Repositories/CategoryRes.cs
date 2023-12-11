using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Repositories
{
    public class CategoryRes : ICategory
    {
        private readonly ShopContext _db;
        private Response res;
        public CategoryRes(ShopContext db)
        {
            _db = db;
            res = new Response();
        }

        public Response CreateCategory(CreateUpdateCategoryViewModel input)
        {
            try
            {
                Category category = new Category();
                category.Title = input.Title;
                _db.Categories.Add(category);
                _db.SaveChanges(); 
                res.Success = true;
                res.Message = "Thêm mới thành công";
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public Response DeleteCategory(Guid IdCategory)
        {
            try
            {
                var result = (from x in _db.Categories
                              where x.IdCategory == IdCategory
                              select x).FirstOrDefault();
                if(result == null)
                {
                    res.Success = false;
                    res.Message = "Không tìm thấy!";
                }
                else
                {
                    result.IsDelete = true;
                    _db.SaveChanges();
                    res.Success = true;
                    res.Message = "Xóa thành công";
                }
            }
            catch(Exception ex)
            {
                res.Success=false;
                res.Message = ex.Message;
            }
            return res;
        }

        public Response GetCategory()
        {
			try
			{
                var result = (from x in _db.Categories
                              where x.IsDelete == false
                              select x).ToList();
                res.Data = result;
                res.Success = true;
			}
			catch (Exception ex)
			{
                res.Data = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public Response UpdateCategory(CreateUpdateCategoryViewModel input)
        {
            try
            {
                var result = (from x in _db.Categories
                              where x.IdCategory == input.IdCategory
                              select x).FirstOrDefault();
                if(result == null)
                {
                    res.Success = false;
                    res.Message = "Không tìm thấy!";
                }
                else
                {
                    result.Title = input.Title;
                    _db.SaveChanges();
                    res.Success = true;
                    res.Message = "Cập nhật thành công";
                }
            }
            catch(Exception ex)
            {
                res.Message = ex.Message;
                res.Success= false;
            }
            return res;
        }
    }
}
