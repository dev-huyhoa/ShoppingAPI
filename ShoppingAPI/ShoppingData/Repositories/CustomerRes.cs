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
    public class CustomerRes : ICustomer
    {
        private readonly ShopContext _db;
        private Response res;
        public CustomerRes(ShopContext db)
        {
            _db = db;
            res = new Response();
        }

        public Response CreateCustomer(CreateCustomerViewModel input)
        {
            try
            {
                Customer cus = new Customer();
                cus.IdCustomer = new Guid();
                cus.NameCustomer = input.NameCustomer;
                cus.Email = input.Email;
                cus.PassWord = input.PassWord;
                cus.Phone = input.Phone;
                cus.Address = input.Address;
                cus.Image = input.Image;
                cus.BirthDay = input.BirthDay;
                cus.CreateDate = DateTime.Now;
                _db.Add(cus);
                _db.SaveChanges();

                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public Response GetCustomer()
        {
            try
            {
                var result = (from x in _db.Customers
                              where x.IsDelete == false
                              select x).ToList();
                res.Data = result;
                res.Success = true;
                res.Message = "";
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }
    }
}
