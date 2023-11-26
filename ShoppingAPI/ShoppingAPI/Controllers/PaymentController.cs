using Microsoft.AspNetCore.Mvc;
using ShoppingContext.Model;
using ShoppingData.Interfaces;
using ShoppingShare.ViewModel;

namespace ShoppingAPI.Controllers
{
    [Route("api/[Controller]")]
    public class PaymentController : Controller
    {
        public IPayment payment;
        public Response res;

        public PaymentController(IPayment _payment)
        {
            payment = _payment;
            res = new Response();
        }
        [HttpPost]
        [Route("createPayment")]
        public object CreatePayMent(CreatePaymentViewModel model)
        {
            res = payment.CreatePayment(model);
            return Ok(res);
        }

        [HttpGet]
        [Route("listPayment")]
        public object GetsPayment()
        {
            res = payment.GetPayment();
            return Ok(res);
        }
    }
}
