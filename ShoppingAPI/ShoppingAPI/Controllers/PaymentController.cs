using Microsoft.AspNetCore.Mvc;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;
using ShoppingShare.ViewModel.Order;
using ShoppingShare.ViewModel.Payment;
using ShoppingShare.ViewModel.Role;

namespace ShoppingAPI.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]

    public class PaymentController : ControllerBase
    {
        public IPayment payment;
        public Response res;

        public PaymentController(IPayment _payment)
        {
            payment = _payment;
            res = new Response();
        }

        [HttpGet]
        [Route("GetPaymentMethods")]
        public IActionResult GetPaymentMethods()
        {
            var result = payment.GetPaymentMethods();
            return Ok(result);
        }

        [HttpPost]
        [Route("InsertPayment")]
        public IActionResult InsertPayment(PaymentViewModel paymentViewModel)
        {

            var id = payment.InsertPayment(paymentViewModel);
            return Ok(id.ToString());
        }

        //Order
        [HttpPost]
        [Route("InsertOrder")]
        public IActionResult InsertOrder(OrderViewModel orderViewModel)
        {
            var id = payment.InsertOrder(orderViewModel);
            return Ok(id.ToString());
        }
    }
}
