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
    public class RoleRes : IRole
    {
        private readonly ShopContext _db;
        private Response res;
        public RoleRes(ShopContext db)
        {
            _db = db;
            res = new Response();
        }

        public Response CreateRole(Role input)
        {
            try
            {
                Role role = new Role();
                role.NameRole  = input.NameRole;  
                role.Description = input.Description;  
                _db.Roles.Add(role);
                _db.SaveChanges();
                res.Message = "Thêm mới thành công";
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Message= ex.Message;
                res.Success = false;
            }
            return res;
        }

        public Response DeleteRole(int IdRole)
        {
            try
            {
                var result = (from x in _db.Roles
                              where x.IdRole == IdRole
                              select x).FirstOrDefault();
                if(result == null)
                {
                    res.Success= false;
                    res.Message = "Không tìm thấy Role";
                }
                else
                {
                    result.IsDelete = true;
                    _db.SaveChanges();
                    res.Message = "Xóa thành công Role";
                    res.Success =true;
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public Response GetsRole()
        {
			try
			{
                var role = (from x in _db.Roles select x).ToList();
                res.Data = role;
                res.Success = true;
			}
			catch (Exception ex)
			{
                res.Message = ex.Message;
				res.Success = false;
			}
            return res;
        }

        public Response UpdateRole(Role input)
        {
            try
            {
                var result = (from x in _db.Roles
                              where x.IdRole == input.IdRole
                              select x).FirstOrDefault();
                if(result == null)
                {
                    res.Message = "Không tìm thấy Role!";
                    res.Success = false;
                }
                else
                {
                    result.NameRole = input.NameRole;
                    result.Description = input.Description;
                    _db.SaveChanges();
                    res.Message = "Cập nhật thành công";
                    res.Success = true;
                }
            }
            catch(Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }
    }
}
