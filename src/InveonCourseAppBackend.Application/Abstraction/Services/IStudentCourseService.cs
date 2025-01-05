using InveonCourseAppBackend.Application.DTOs.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Abstraction.Services
{
    public interface IStudentCourseService
    {
        Task<IEnumerable<CourseDto>> GetCoursesByUserIdAsync(Guid userId);
    }
}
