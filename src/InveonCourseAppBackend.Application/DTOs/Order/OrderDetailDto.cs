using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.DTOs.Order
{
    public class OrderDetailDto
    {
        public Guid OrderId { get; set; }
        public List<string> CourseNames { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid? PaymentId { get; set; }
        public string PaymentStatus { get; set; }
    }
}
