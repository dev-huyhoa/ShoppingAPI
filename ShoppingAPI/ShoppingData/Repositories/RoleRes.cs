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
    }
}
