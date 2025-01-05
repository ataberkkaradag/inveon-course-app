using InveonCourseAppBackend.Application.DTOs.Course;
using InveonCourseAppBackend.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.DTOs.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public UserDto User { get; set; }
        public Guid? PaymentId { get; set; }
        public string PaymentStatus { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
