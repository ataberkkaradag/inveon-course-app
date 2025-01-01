using InveonCourseAppBackend.Application.DTOs.Category;
using InveonCourseAppBackend.Application.DTOs.Course;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Abstraction.Services
{
    public interface ICourseService
    {
        Task<CourseDto> GetCourseByIdAsync(Guid id);
        Task<IEnumerable<CourseDto>> GetAllCourseAsync();
        Task AddCourseAsync(CourseCreateDto courseCreateDto);
        Task UpdateCourseAsync(Guid id, CourseUpdateDto courseUpdateDto);
        Task DeleteCourseAsync(Guid id);
    }
}
