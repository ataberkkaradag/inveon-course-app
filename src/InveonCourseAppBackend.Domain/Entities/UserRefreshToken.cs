using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Domain.Entities
{
    public class UserRefreshToken
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
