using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get;  set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid? PaymentId { get; set; }
        public Payment Payment { get; set; }
        public ICollection<Course> Courses { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
