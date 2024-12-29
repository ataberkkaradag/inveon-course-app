using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Infrastructure.Repositories
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(ApplicationDbContext context):base(context) { }
        
    }
}
