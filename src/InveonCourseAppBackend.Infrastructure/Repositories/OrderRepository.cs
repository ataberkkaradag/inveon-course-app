using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Infrastructure.Repositories
{
    public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context) : base(context) { _context = context; }

        public async Task<Order> GetByIdWithCoursesAsync(Guid orderId)
        {
            return await _context.Orders
                .Include(o => o.Courses)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
