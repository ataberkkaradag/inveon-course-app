using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Order;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICourseRepository _courseRepository;

        public OrderService(IOrderRepository orderRepository, ICourseRepository courseRepository)
        {
            _orderRepository = orderRepository;
            _courseRepository = courseRepository;
        }
        public async Task<OrderDto> CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            
            var courses = await _courseRepository.FindAsync(c => orderCreateDto.CourseIds.Contains(c.Id));

            if (courses == null || !courses.Any())
                throw new Exception("Courses not found");

            
            var totalPrice = courses.Sum(c => c.Price);

           
            var order = new Order
            {
                UserId = orderCreateDto.UserId,
                OrderDate = DateTime.UtcNow,
                Courses = courses.ToList(),
                TotalPrice = totalPrice
            };

           
            await _orderRepository.CreateAsync(order);

            
            var orderDto = new OrderDto
            {
                Id = order.Id,
                
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                
            };

            return orderDto;
        }

        public async Task<OrderDetailDto> GetOrderByIdAsync(Guid orderId)
        {
            var order=await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");
            return new OrderDetailDto
            {
                OrderId = order.Id,
                UserId = order.UserId,
                UserName=order.User.UserName,
                CourseNames=order.Courses.Select(c=>c.Title).ToList(),  
                TotalPrice=order.TotalPrice,
                OrderDate=order.OrderDate,
                PaymentId=order.PaymentId,
                PaymentStatus=order.Payment?.PaymentStatus.ToString() ??"Not Paid"

            };
        }

        public async Task<IEnumerable<OrderListDto>> GetOrdersByUserAsync(Guid userId)
        {
            var orders=await _orderRepository.FindAsync(o=>o.UserId == userId);

            return orders.Select(o=>new OrderListDto {OrderId=o.Id, OrderDate=o.OrderDate,TotalPrice=o.TotalPrice});
        }
    }
}
