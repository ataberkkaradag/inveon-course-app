﻿using InveonCourseAppBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.Abstraction.Repositories
{
    public interface IPaymentRepository:IRepository<Payment>
    {
        Task<Payment> GetPaymentByOrderIdAsync(Guid orderId);
        Task<IEnumerable<Payment>> GetPaymentsByUserIdAsync(Guid userId);
    }
}
