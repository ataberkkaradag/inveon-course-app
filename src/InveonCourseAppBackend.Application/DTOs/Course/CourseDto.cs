using InveonCourseAppBackend.Application.DTOs.Category;
using InveonCourseAppBackend.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.DTOs.Course
{
    public class CourseDto
    {
        public Guid Id { get;  set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public UserDto Insturctor { get; set; }
        public CategoryDto Category { get; set; }    
        
    }
}
