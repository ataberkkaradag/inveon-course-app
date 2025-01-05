using InveonCourseAppBackend.Application.DTOs.Token;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Abstraction.Services
{
    public interface ITokenService
    {
         TokenDto CreateToken(User user);

    }
}
