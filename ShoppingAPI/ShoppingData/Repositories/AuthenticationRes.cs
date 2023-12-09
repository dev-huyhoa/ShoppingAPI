using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Repositories
{
    public class AuthenticationRes : IAuthentication
    {
        private readonly ShopContext _db;
        private Response res;
        private IConfiguration configuration;
        public AuthenticationRes(ShopContext db, IConfiguration _configuration)
        {
            _db = db;
            res = new Response();
            configuration = _configuration;

            //_authen = optionsMonitor.CurrentValue;
        }
        public Response Login(LoginViewModel model)
        {
            try
            {
                var user = _db.Employees.SingleOrDefault(p => p.Email == model.Email && p.Password == model.Password && p.IsDelete == false);
                if (user == null)
                {
                    res.Success = false;
                    res.Message = "Sai tài khoản hoặc mật khẩu";
                }
                else
                {
                    res.Success = true;                  
                    res.Data = GenerateToken(user); ;
                }
                return res;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
                return res;
            }
        }

        public Response LoginWithNewPass(string email,string newPassword)
        {
            try
            {
                var user = (from x in _db.Employees
                            where x.Email == email
                            select x).FirstOrDefault();
                if (user == null)
                {
                    res.Success = false;
                    res.Message = "Không tìm thấy email này!";
                }
                else
                {
                    user.Password = newPassword;
                    _db.SaveChanges();
                    res.Success = true;
                    res.Message = "Đổi mật khẩu thành công";
                }
            }
            catch(Exception ex)
            {
                res.Success = false;
                res.Message= ex.Message;
            }
            return res;
        }

        private Authentication GenerateToken(Employee result)
        {
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(configuration["SecretKey:Key"]);
            var tokeDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, result.Email),
                    //cần gì để show thì thêm vào
                    new Claim(ClaimTypes.Name, result.NameEmployee),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandle.CreateToken(tokeDescription);
            var tokenJWT = jwtTokenHandle.WriteToken(token);

            Authentication auth = new Authentication();
            auth.Token = tokenJWT;
            auth.RoleId = result.RoleId;
            auth.Id = result.IdEmployee;
            auth.Name = result.NameEmployee;
            auth.Phone = result.Phone;
            auth.Image = result.Image;
            auth.Email = result.Email;
            return auth;
        }

    }
}
