using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonCourseAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(CreatePaymentDto createPaymentDto)
        {
            var payment = await _paymentService.ProcessPaymentAsync(createPaymentDto);
            return Ok(payment);
        }

        [HttpGet("paymentbyorder")]
        public async Task<IActionResult> GetPaymentByOrderId(Guid orderId)
        {
            var payment = await _paymentService.GetPaymentByOrderIdAsync(orderId);
            if (payment == null)
                return NotFound();
            return Ok(payment);
        }

        [HttpGet("paymentbyuser")]
        public async Task<IActionResult> GetPaymentsByUserId(Guid userId)
        {
            var payments = await _paymentService.GetPaymentsByUserIdAsync(userId);
            return Ok(payments);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentById(Guid id) 
            {
                var payment = await _paymentService.GetPaymentByIdAsync(id);
                return Ok(payment);
          }
        }
    
}
