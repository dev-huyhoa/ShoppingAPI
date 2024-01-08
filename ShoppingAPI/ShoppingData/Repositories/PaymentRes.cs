using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Order;
using ShoppingShare.ViewModel.Payment;
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

        public List<PaymentMethod> GetPaymentMethods()
        {
            var payment = new List<PaymentMethod>();
            try
            {
                var result = (from x in _db.PaymentMethods
                              select x).ToList();
                foreach (var item in result)
                {
                    PaymentMethod paymentMethod = new()
                    {
                        IdPaymentMethod = item.IdPaymentMethod,
                        Type = item.Type,
                        Provider = item.Provider,
                        Available = item.Available,
                        Reason = item.Reason
                    };
                    payment.Add(paymentMethod);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return payment;

        }

        public int InsertPayment(PaymentViewModel payment)
        {
            int value = 0;
            try
            {
                Payment pay = new Payment();
                pay.PaymentMethodId = pay.PaymentMethodId;
                pay.CustomerId = pay.CustomerId;
                pay.TotalAmount = payment.TotalAmount;
                pay.ShippingCharges = payment.ShipingCharges;
                pay.AmoutReduced = pay.AmoutReduced;
                pay.AmountPaid = payment.AmountPaid;
                pay.CreateAt = DateTime.Now;
                _db.Add(pay);
                _db.SaveChanges();

                int highestId = _db.Payments.OrderByDescending(p => p.Id).Select(p => p.Id).FirstOrDefault();
                value = highestId;
            }
            catch (Exception)
            {
                value = 0;
                throw;
            }
            return value;
        }

        public int InsertOrder(OrderViewModel input)
        {
            int value = 0;
            try
            {

                Order order = new Order();
                order.CustomerId = input.User.Id;
                order.CartId = input.Cart.Id;
                order.IdPayment = input.Payment.Id;
                order.CreateAt = DateTime.Now;
                _db.Orders.Add(order);
                _db.SaveChanges();

                var result = (from x in _db.Carts
                              where x.IdCart == input.Cart.Id
                              select x).FirstOrDefault();
                result.Ordered = true;
                result.OrderedOn = DateTime.Now;
                _db.SaveChanges();
                int IdOrder = _db.Orders.OrderByDescending(p => p.IdOrder).Select(p => p.IdOrder).FirstOrDefault();
                
            }
            catch (Exception)
            {
                throw;
            }
            return value;
        }
    }
}
