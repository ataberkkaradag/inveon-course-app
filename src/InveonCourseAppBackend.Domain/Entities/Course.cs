using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Domain.Entities
{
    public class Course
    {
        public Course()
        {
           Id = Guid.NewGuid();
        }
        public Guid Id { get;  set; }

        public string Title { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid InstructorId { get; set; }
        public User Instructor { get; set; } 

        public ICollection<Order>? Orders { get; set; }
        public ICollection<StudentCourse>? StudentCourses { get; set; }
    }
}
