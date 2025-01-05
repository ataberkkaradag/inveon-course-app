using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Course;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Services
{
    public class StudentCourseService:IStudentCourseService
    {
        private readonly IStudentCourseRepository _studentCourseRepository;

        public StudentCourseService(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesByUserIdAsync(Guid userId)
        {
            var studentCourses = await _studentCourseRepository
       .FindAll()
       .Where(sc => sc.StudentId == userId)
       .Include(sc => sc.Course) 
       .ToListAsync();

            return studentCourses.Select(sc => new CourseDto
            {
               Id = sc.Course.Id,
                Title = sc.Course.Title,
                Description = sc.Course.Description,
                Price = sc.Course.Price
            });
        }
    }
}
