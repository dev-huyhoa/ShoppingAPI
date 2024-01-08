using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.Ultilities;
using ShoppingShare.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
                res.Message = "Thêm mới thành công ";
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public Response DeleteCustomer(Guid IdCustomer)
        {
            try
            {
                var result = (from x in _db.Customers
                              where x.IdCustomer == IdCustomer
                              select x).FirstOrDefault();
                if(result == null)
                {
                    res.Message = "Không tìm thấy khách hàng!";
                    res.Success= false;
                }
                else
                {
                    result.IsDelete = true;
                    _db.SaveChanges();
                    res.Message = "Xóa thành công";
                    res.Success= true;
                }
            }
            catch (Exception ex)
            {
                res.Success=false;
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

        public Response GetListCusDeleted()
        {
            try
            {
                var cus = (from x in _db.Customers
                           where x.IsDelete == true
                           select x).ToList();
                if(cus != null)
                {
                    res.Data = cus;
                    res.Success = true;
                    res.Message = "";
                }
                else
                {
                    res.Success = false;
                    res.Message = "Chưa có khách hàng nào bị xóa!";
                }

            }
            catch(Exception ex)
            {
                res.Success = false; 
                res.Message = ex.Message;
            }
            return res;
        }

        public Response SendPassCus(string email, string subject)
        {
            try
            {
                var result = (from x in _db.Customers
                              where x.Email == email
                              select x).FirstOrDefault();
                if (result != null)
                {
                    Random rd = new Random();
                    Ultility.SendMail(email, subject, rd.Next().ToString());
                    res.Success = true;
                    res.Message = "Gửi mật khẩu mới thành công";
                    
                }
                else
                {
                    res.Success= false;
                    res.Message = "Không tìm thấy email này!";
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public Response UpdateCustomer(CreateCustomerViewModel input)
        {
            try
            {
                var result = (from x in _db.Customers
                              where x.IdCustomer == input.IdCustomer
                              select x).FirstOrDefault();
                if(result == null)
                {
                    res.Message = "Không tìm thấy khách hàng!";
                    res.Success = false;
                }
                else
                {
                    result.Address = input.Address;
                    result.NameCustomer = input.NameCustomer;
                    result.PassWord = input.PassWord;  
                    result.Email = input.Email;
                    result.Phone = input.Phone;    
                    result.BirthDay = input.BirthDay;
                    result.Image = input.Image;
                    _db.SaveChanges();
                    res.Message = "Cập nhật thành công";
                    res.Success = true;

                }
            }
            catch(Exception ex)
            {
                res.Message = ex.Message;
            }
            return res;
        }


        #region customer
        public string CustomerLogin(string email, string password)
        {
            Customer customer = new Customer();
            try
            {
                var result = (from x in _db.Customers
                              where x.Email == email && x.PassWord == password
                              select x);
                int count = result.Count();
                if (count == 0)
                {
                    return "";
                }

                var querry = (from x in _db.Customers
                              where x.Email == email && x.PassWord == password
                              select x).FirstOrDefault();
                customer.IdCustomer = querry.IdCustomer;
                customer.NameCustomer = querry.NameCustomer;
                customer.Address = querry.Address;
                customer.Phone = querry.Phone;
                customer.PassWord = querry.PassWord;
                customer.CreateDate = querry.CreateDate;
                customer.BirthDay = querry.BirthDay;
                customer.Email = querry.Email;

                string key = "MNU66iBl3T5rh6H52i69";
                string duration = "60";
                var symmetrickey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(symmetrickey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
     {
                    new Claim("id", customer.IdCustomer.ToString()),
                    new Claim("lastName", customer.NameCustomer),
                    new Claim("address", customer.Address),
                    new Claim("mobile",  customer.Phone),
                    new Claim("email", customer.Email),
                    new Claim("password", customer.PassWord)

                };


                var jwtToken = new JwtSecurityToken(
                    issuer: "localhost",
                    audience: "localhost",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Int32.Parse(duration)),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(jwtToken);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
