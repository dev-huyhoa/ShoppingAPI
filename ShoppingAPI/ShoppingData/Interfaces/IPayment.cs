using ShoppingContext.Model;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Order;
using ShoppingShare.ViewModel.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingData.Interfaces
{
    public interface IPayment
    {
        List<PaymentMethod> GetPaymentMethods();
        int InsertPayment(PaymentViewModel payment);
        int InsertOrder(OrderViewModel input);
    }
}
