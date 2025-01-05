using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Domain.Entities
{
    public class User:IdentityUser<Guid>
    {
        public ICollection<StudentCourse>? SubscribedCourses { get; set;}
        public ICollection<Course>? CreatedCourses { get; set; }

        public ICollection<Order>? Orders { get; set; }  
    }
}
