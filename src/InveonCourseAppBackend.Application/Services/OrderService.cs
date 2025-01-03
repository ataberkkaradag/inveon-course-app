using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Category;
using InveonCourseAppBackend.Application.DTOs.Course;
using InveonCourseAppBackend.Application.DTOs.Order;
using InveonCourseAppBackend.Application.DTOs.User;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly IStudentCourseRepository _studentCourseRepository;
        private readonly UserManager<User> _userManager;

        public OrderService(IOrderRepository orderRepository, ICourseRepository courseRepository,IStudentCourseRepository studentCourseRepository,UserManager<User> userManager)
        {
            _orderRepository = orderRepository;
            _courseRepository = courseRepository;
            _studentCourseRepository = studentCourseRepository;
            _userManager = userManager;
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

            var studentCourses = courses.Select(course => new StudentCourse
            {
                StudentId = orderCreateDto.UserId,
                CourseId = course.Id,
                SubscriptionDate = DateTime.UtcNow
            }).ToList();
            foreach (var studentCourse in studentCourses)
            {
                await _studentCourseRepository.CreateAsync(studentCourse);
            }
            var user = await _userManager.Users
      .Include(u => u.SubscribedCourses)
      .Include(u => u.Orders)
      .FirstOrDefaultAsync(u => u.Id == orderCreateDto.UserId);

            if (user == null)
                throw new Exception("User not found");

            // Navigasyon özelliklerini güncelle
            if (user.SubscribedCourses == null)
                user.SubscribedCourses = new List<StudentCourse>();

            foreach (var studentCourse in studentCourses)
            {
                user.SubscribedCourses.Add(studentCourse);
            }

            if (user.Orders == null)
                user.Orders = new List<Order>();

            user.Orders.Add(order);

            // Kullanıcıyı güncelle
            await _userManager.UpdateAsync(user);


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
                .Include(o => o.User).Include(o => o.Payment).Include(o=>o.Courses).ThenInclude(c => c.Instructor).FirstOrDefaultAsync();
            if (order == null)
                throw new Exception("Order not found");
            return new OrderDto
            {
                Id = order.Id,
                
                User=new UserDto {Id=order.User.Id,Email=order.User.Email,UserName=order.User.Email },
                
                TotalPrice=order.TotalPrice,
                OrderDate=order.OrderDate,
                PaymentId=order.PaymentId,
                Courses= order.Courses.Select(course => new CourseDto
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description,
                    Price = course.Price,
                    Instructor = new UserDto
                    {
                        Id=course.InstructorId,
                        UserName = course.Instructor.UserName,
                        Email = course.Instructor.Email
                    }
                    
                }).ToList(),
                PaymentStatus =order.Payment?.PaymentStatus.ToString() ??"Not Paid"
                

            };
        }

        public async Task<IEnumerable<OrderListDto>> GetOrdersByUserAsync(Guid userId)
        {
            var orders=await _orderRepository.FindAsync(o=>o.UserId == userId);

            return orders.Select(o=>new OrderListDto {OrderId=o.Id, OrderDate=o.OrderDate,TotalPrice=o.TotalPrice});
        }
    }
}
