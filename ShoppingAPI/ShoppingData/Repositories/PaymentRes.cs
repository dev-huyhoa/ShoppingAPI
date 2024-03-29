﻿using ShoppingContext.Model;
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

        public Response GetPaymentOrder()
        {
            try
            {
                var result = (from x in _db.Payments
                              where x.Status == false
                              select x).ToList();
                res.Data = result;
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        public Response UpdateStatusPayment(int idPayment, bool statusPM)
        {
            try
            {
                var result = (from x in _db.Payments
                              where x.Id == idPayment
                              select x).FirstOrDefault();
                if (result != null)
                {
                    res.Message = "Update đơn hành thành công";
                    result.Status = statusPM;
                    _db.SaveChanges();
                }
                else
                {
                    res.Success = false;
                    res.Message = "Không tìm thấy đơn hàng";
                }
                res.Success = true;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
            }
            return res;
        }

        // customer
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
                pay.PaymentMethodId = payment.PaymentMethod.IdPaymentMethod;
                pay.CustomerId = payment.User.Id;
                pay.TotalAmount = payment.TotalAmount;
                pay.ShippingCharges = payment.ShipingCharges;
                pay.AmoutReduced = payment.AmountReduced;
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
