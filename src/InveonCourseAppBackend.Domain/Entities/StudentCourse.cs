using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Domain.Entities
{
    public class StudentCourse
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public User Student { get; set; } 
        public Guid CourseId { get; set; }
        public Course Course { get; set; } 
        public DateTime SubscriptionDate { get; set; }
    }
}
