using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.DTOs.Token
{
    public class TokenResponse
    {
        public string Token { get; set; } 
        public DateTime TokenExpireDate { get; set; }
    }
}
