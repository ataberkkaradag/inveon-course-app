using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Course;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task AddCourseAsync(CourseCreateDto courseCreateDto)
        {
            var course = new Course
            {
                Title = courseCreateDto.Title,
                Description = courseCreateDto.Description,
                Price = courseCreateDto.Price,
                CategoryId = courseCreateDto.CategoryId,
                InstructorId = courseCreateDto.InstructorId,

            };

            await _courseRepository.CreateAsync(course);
            
        }

        public async Task DeleteCourseAsync(Guid id)
        {
            await _courseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Course>> GetAllCourseAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course> GetCourseByIdAsync(Guid id)
        {
           var course=await _courseRepository.GetByIdAsync(id);
            if (course == null) 
            {
                throw new Exception("course not found");
            }
            return course;
        }

        public async Task UpdateCourseAsync(Guid id, CourseUpdateDto courseUpdateDto)
        {
            var existingCourse=await _courseRepository.GetByIdAsync(id);

            existingCourse.Description = courseUpdateDto.Description;
            existingCourse.Price = courseUpdateDto.Price;
            existingCourse.Title = courseUpdateDto.Title;
            existingCourse.CategoryId = courseUpdateDto.CategoryId;
            
            await _courseRepository.UpdateAsync(existingCourse.Id,existingCourse);
        }
    }
}
