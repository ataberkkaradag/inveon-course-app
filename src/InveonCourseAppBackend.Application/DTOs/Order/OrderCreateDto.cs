using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.DTOs.Order
{
    public class OrderCreateDto
    {
        public Guid UserId { get; set; }
        public List<Guid> CourseIds { get; set; }
        
    }
}
