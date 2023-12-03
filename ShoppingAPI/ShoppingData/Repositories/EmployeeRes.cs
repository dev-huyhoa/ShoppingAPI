using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.Ultilities;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ShoppingData.Repositories
{
    public class EmployeeRes : IEmployee
    {
        private readonly ShopContext _db;
        private Response res;
        public EmployeeRes(ShopContext db)
        {
            _db = db;
            res = new Response();
        }
        public Response GetsEmployee()
        {
			try
			{
                var result = (from x in _db.Employees
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

        public Response CreateEmployee(CreateEmpViewModel input, ICollection<IFormFile> files)
        {
            try
            {
                Employee emp = new Employee();
                emp.IdEmployee = new Guid();
                emp.NameEmployee = input.NameEmployee;
                emp.Email = input.Email;
                emp.CreateDate = DateTime.Now;
                emp.RoleId = input.RoleId;
                emp.Address = input.Address;
                emp.Password = "123";
                foreach (var file in files)
                {
                    emp.Image = Ultility.WriteFile(file, "Employee", emp.IdEmployee.ToString());
                }
                emp.Image = input.Image;
                emp.Phone = input.Phone;
                emp.Status = true;
                _db.Employees.Add(emp);
                _db.SaveChanges();
                res.Message = "Thêm mới thành công ";
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Message = "Thêm mới thất bại !";
                res.Success = false;
            }
            return res;
        }

        public Response UpdateEmployee(UpdateEmpViewModel input)
        {
            try
            {
                var result = (from x in _db.Employees
                              where x.IdEmployee == input.IdEmployee
                              select x).FirstOrDefault();
                if (result == null)
                {
                    res.Message = "Không tìm thấy nhân viên !";
                    res.Success= false;
                }
                else
                {
                    result.NameEmployee = input.NameEmployee;
                    result.Email = input.Email;
                    result.Phone = input.Phone;
                    result.Image = input.Image;
                    result.RoleId = input.RoleId;
                    result.Status = input.Status;
                    result.Address = input.Address;
                    result.Image = input.Image;

                    _db.SaveChanges();
                    res.Message = "Cập nhật thành công";
                    res.Success = true;
                }
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public Response GetEmployeeById(Guid idEmployee)
        {
            try
            {
                var result = (from x in _db.Employees
                              where x.IdEmployee == idEmployee
                              select x).FirstOrDefault();
                if (result == null)
                {
                    res.Message = "Nhân viên không tồn tại !";
                    res.Success = false;
                }
                else
                {
                    res.Data = result;
                    res.Success = true;
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public Response DeleteEmployee(Guid idEmployee)
        {
            try
            {
                var emp = (from x in _db.Employees
                              where x.IdEmployee == idEmployee
                              select x).FirstOrDefault();
                if (emp != null)
                {
                    emp.IsDelete = true;
                    _db.SaveChanges();
                    res.Message = "Xóa nhân viên thành công";
                    res.Success = true;
                }
                else
                {
                    res.Message = "Không tìm thấy nhân viên !";
                    res.Success = false;
                }
            }
            catch (Exception ex)
            {

                res.Message = ex.Message;
                res.Success = false;
            }
            return res;
        }

        public Response UpdateEmpImage(ICollection<IFormFile> files, UpdateEmpViewModel input)
        {
            try
            {
                var result = (from x in _db.Employees
                              where x.IdEmployee == input.IdEmployee
                              select x).FirstOrDefault();
                if (result == null)
                {
                    res.Message = "Không tìm thấy nhân viên !";
                    res.Success = false;
                }
                else
                {
                    result.NameEmployee = input.NameEmployee;
                    result.Email = input.Email;
                    result.Phone = input.Phone;
                    result.Image = input.Image;
                    result.RoleId = input.RoleId;
                    result.Status = input.Status;
                    result.Address = input.Address;
                    foreach (var file in files)
                    {
                        result.Image = Ultility.WriteFile(file, "Employee", input.IdEmployee.ToString());
                    }

                    _db.SaveChanges();
                    res.Message = "Cập nhật thành công";
                    res.Success = true;
                }
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
