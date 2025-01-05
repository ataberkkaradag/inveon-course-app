using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Category;
using InveonCourseAppBackend.Application.DTOs.Course;
using InveonCourseAppBackend.Application.DTOs.User;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public CourseService(ICourseRepository courseRepository, IUserRepository userRepository, UserManager<User> userManager)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            

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

            var instructor = await _userManager.Users
      .Include(u => u.CreatedCourses)
      .FirstOrDefaultAsync(u => u.Id == courseCreateDto.InstructorId);
            if (instructor == null)
                throw new Exception("Instructor not found");

            
            if (instructor.CreatedCourses == null)
                instructor.CreatedCourses = new List<Course>();

            instructor.CreatedCourses.Add(course);

      
            await _userManager.UpdateAsync(instructor);
        }



        public async Task DeleteCourseAsync(Guid id)
        {
            await _courseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CourseDto>> GetAllCourseAsync()
        {
            var courses = _courseRepository.FindAll();

            return await courses.Select(course => new CourseDto
            {
                Id=course.Id,
                Title= course.Title,
                Description= course.Description,
                Price = course.Price,
                Instructor= new UserDto { Id=course.Instructor.Id,UserName=course.Instructor.UserName,Email=course.Instructor.Email},
                Category=new CategoryDto { Id=course.Category.Id, Name=course.Category.Name }


            }).ToListAsync();
        }

        public async Task<CourseDto> GetCourseByIdAsync(Guid id)
        {
            var course = await _courseRepository.FindAll().Where(c => c.Id == id)
                .Include(c=>c.Instructor).Include(c=>c.Category).FirstOrDefaultAsync();
            if (course == null) 
            {
                throw new Exception("course not found");
            }
            return  new CourseDto
        {
               Id = course.Id,
               Title = course.Title, 
            Description = course.Description,
            Price = course.Price,
            Instructor = new UserDto { Id = course.Instructor.Id ,UserName = course.Instructor.UserName, Email = course.Instructor.Email },
              Category = new CategoryDto { Id = course.Category.Id, Name = course.Category.Name }
            };
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
