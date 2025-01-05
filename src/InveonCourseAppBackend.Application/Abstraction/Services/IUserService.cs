
using InveonCourseAppBackend.Application.DTOs.User;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Abstraction.Services
{
    public  interface IUserService
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        
        Task<IdentityResult> UpdateUserAsync(Guid id, UserUpdateDto userUpdateDto);
        Task<IdentityResult> DeleteUserAsync(Guid id);
    }
}
