using InveonCourseAppBackend.Application.DTOs.Payment;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Abstraction.Services
{
    public interface IPaymentService
    {
        Task<PaymentDto> ProcessPaymentAsync(CreatePaymentDto dto);
        Task<PaymentDto> GetPaymentByIdAsync(Guid paymentId);
        Task<IEnumerable<PaymentDto>> GetPaymentsByUserIdAsync(Guid userId);
        Task<PaymentDto> GetPaymentByOrderIdAsync(Guid orderId);
    }
}
