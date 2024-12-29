using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.DTOs.Course
{
    public class CourseDto
    {
        public Guid Id { get; private set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public Guid InstructorId { get; set; }
    }
}
