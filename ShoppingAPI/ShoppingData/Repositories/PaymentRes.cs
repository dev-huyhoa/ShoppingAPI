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
    public class PaymentRes : IPayment
    {
        private readonly ShopContext _db;
        private Response res;
        public PaymentRes(ShopContext db)
        {
            _db = db;
            res = new Response();
        }

        public Response CreatePayment(CreatePaymentViewModel input)
        {
            try
            {
                Payment payment = new Payment();
                payment.Name = input.Name;
                _db.Add(payment);
                _db.SaveChanges();

                res.Success = true;

            }
            catch(Exception ex) 
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;

        }

        public Response GetPayment()
        {
            try
            {
                var result = (from x in _db.Payments
                              select x).ToList(); 
                res.Data = result;  
                res.Success = true;
                res.Message = "";
            }
            catch(Exception ex) 
            {
                res.Message = ex.Message;
            }
            return res;
        }
    }
}
