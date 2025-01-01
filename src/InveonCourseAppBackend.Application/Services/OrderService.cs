using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Order;
using InveonCourseAppBackend.Application.DTOs.User;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            var order=await _orderRepository.FindAll().Where(o => o.Id == id)
                .Include(o => o.User).Include(o => o.Payment).FirstOrDefaultAsync();
            if (order == null)
                throw new Exception("Order not found");
            return new OrderDto
            {
                Id = order.Id,
                
                User=new UserDto {Id=order.User.Id,Email=order.User.Email,UserName=order.User.Email },
                
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
