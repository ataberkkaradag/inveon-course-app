using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Infrastructure.Repositories
{
    public class CourseRepository:GenericRepository<Course>,ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context): base(context) { }
        
    }
}
