using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application.DTOs.Payment
{
    public class CreatePaymentDto
    {
        public Guid OrderId { get; set; }
        public decimal Price { get; set; }
    }
}
