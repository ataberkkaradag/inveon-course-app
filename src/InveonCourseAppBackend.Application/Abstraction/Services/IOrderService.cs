using InveonCourseAppBackend.Application.DTOs.Order;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Abstraction.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderCreateDto orderCreateDto); 
        Task<OrderDetailDto> GetOrderByIdAsync(Guid orderId); 
        Task<IEnumerable<OrderListDto>> GetOrdersByUserAsync(Guid userId);
    }
}
