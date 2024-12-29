using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.DTOs.User
{
    public class UserUpdateDto
    {
       public Guid Id { get; set; }

        
        public string UserName { get; set; }

        
        public string Email { get; set; }
    }
}
