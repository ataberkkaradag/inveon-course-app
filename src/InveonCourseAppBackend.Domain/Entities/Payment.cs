using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Domain.Entities
{
    public class Payment
    {
        public Payment()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; } 
        public decimal Price { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; } = "InProgress";
    }
}
