
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Course;
using InveonCourseAppBackend.Application.Services;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonCourseAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetAllCourseAsync();
            return Ok(courses);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(Guid id) 
        {
            var course=await _courseService.GetCourseByIdAsync(id);
            return Ok(course);
        }
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseCreateDto courseCreateDto)
        {


            await _courseService.AddCourseAsync(courseCreateDto);
            return Ok(courseCreateDto);
        }
        [Authorize(Roles ="Instructor")]
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(CourseUpdateDto courseUpdateDto)
        {
            await _courseService.UpdateCourseAsync(courseUpdateDto.Id, courseUpdateDto);
            return NoContent();
        }
        [Authorize(Roles = "Instructor")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }
    }
}
