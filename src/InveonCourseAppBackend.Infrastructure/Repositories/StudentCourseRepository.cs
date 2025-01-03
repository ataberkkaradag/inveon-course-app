using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Infrastructure.Repositories
{
    public class StudentCourseRepository:GenericRepository<StudentCourse>,IStudentCourseRepository
    {
        public StudentCourseRepository(ApplicationDbContext context) : base(context) { }
        
    }
}
