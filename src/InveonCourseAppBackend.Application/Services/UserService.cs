using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.DTOs.User;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> DeleteUserAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            var result= await _userManager.DeleteAsync(user);
            return result;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {

            return await Task.FromResult(_userManager.Users.ToList());
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<IdentityResult> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto)
        {
            var existingUser=await _userManager.FindByIdAsync(id.ToString());
            existingUser.Email=userUpdateDto.Email;
            existingUser.UserName=userUpdateDto.UserName;
            var result=await _userManager.UpdateAsync(existingUser);
            return result;

           
        }
    }
}
