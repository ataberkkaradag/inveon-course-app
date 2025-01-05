using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Payment;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;

        public PaymentService(IPaymentRepository paymentRepository,IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
        }
        public async Task<PaymentDto> GetPaymentByIdAsync(Guid paymentId)
        {
           var payment =await _paymentRepository.GetByIdAsync(paymentId);
            if (payment == null)
                throw new Exception("Payment not Found");

            return new PaymentDto 
            { Id = payment.Id,
              PaymentDate = payment.PaymentDate,
              Price=payment.Price,
             PaymentStatus=payment.PaymentStatus};
        }

        public async Task<PaymentDto> GetPaymentByOrderIdAsync(Guid orderId)
        {
            var payment= await _paymentRepository.GetPaymentByOrderIdAsync(orderId);
            if (payment == null)
                throw new Exception("Payment not Found");
            return new PaymentDto
            {
                Id = payment.Id,
                
                Price = payment.Price,
                PaymentDate = payment.PaymentDate,
                PaymentStatus = payment.PaymentStatus
            };
        }

        public  async Task<IEnumerable<PaymentDto>> GetPaymentsByUserIdAsync(Guid userId)
        {
            var payments =await _paymentRepository.GetPaymentsByUserIdAsync(userId);

            return payments.Select(payment => new PaymentDto
            {
                Id = payment.Id,
              
                Price = payment.Price,
                PaymentDate = payment.PaymentDate,
                PaymentStatus = payment.PaymentStatus
            });
        }

        public async Task<PaymentDto> ProcessPaymentAsync(CreatePaymentDto createPaymentDto)
        {
            var order = await _orderRepository.GetByIdAsync(createPaymentDto.OrderId);
            if (order == null)
                throw new Exception("Order not found.");

            var payment = new Payment
            {
                OrderId = order.Id,
                Price = createPaymentDto.Price,
                PaymentDate = DateTime.UtcNow,
                PaymentStatus = "Completed"
            };
            await _paymentRepository.CreateAsync(payment);
            order.PaymentId=payment.Id;
            await _orderRepository.UpdateAsync(order.Id,order);
            return new PaymentDto
            {
                Id = payment.Id,
                
                Price = payment.Price,
                PaymentDate = payment.PaymentDate,
                PaymentStatus = payment.PaymentStatus
            };
        }
    }
}
