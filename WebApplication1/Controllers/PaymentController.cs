using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService _paymentService; 
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result=_paymentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("GetByUserId")]
        public IActionResult GetAll(int id)
        {
            var result = _paymentService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }




        [HttpPost("Add")]
        public IActionResult Add(Payment payment)
        {
            var result = _paymentService.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }
           return BadRequest();
        }
        [HttpPost("Update")]
        public IActionResult Update(Payment payment)
        {
            var result = _paymentService.Update(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Payment payment)
        {
            var result = _paymentService.Delete(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
