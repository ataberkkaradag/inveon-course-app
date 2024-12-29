using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.Category;
using InveonCourseAppBackend.Application.DTOs.User;
using InveonCourseAppBackend.Application.Services;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InveonCourseAppBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {

            await _userService.UpdateUserAsync(userUpdateDto.Id,userUpdateDto);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }


    }
}
