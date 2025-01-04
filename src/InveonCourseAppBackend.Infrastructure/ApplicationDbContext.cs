using InveonCourseAppBackend.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace InveonCourseAppBackend.Infrastructure
{
     public class ApplicationDbContext:IdentityDbContext<User,Role,Guid>
     {

         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
         {

         }



         public DbSet<Course> Courses { get; set; }
         public DbSet<StudentCourse> StudentCourses { get; set; }
         public DbSet<Category> Categories { get; set; }
         public DbSet<Payment> Payments { get; set; }
         public DbSet<Order> Orders { get; set; }



         protected override void OnModelCreating(ModelBuilder builder)
         {
             base.OnModelCreating(builder);
             builder.Entity<User>().HasMany(u => u.SubscribedCourses).WithOne(sc => sc.Student)
                 .HasForeignKey(u => u.StudentId);
             builder.Entity<User>().HasMany(u=>u.CreatedCourses).WithOne(cc => cc.Instructor).HasForeignKey(cc => cc.InstructorId);

             builder.Entity<Course>().HasMany(c=>c.StudentCourses).WithOne(sc => sc.Course);

             builder.Entity<Course>().HasKey(c=>c.Id);
             builder.Entity<Course>().HasOne(c => c.Instructor)
                 .WithMany(u=>u.CreatedCourses).HasForeignKey(c => c.InstructorId).OnDelete(DeleteBehavior.Restrict);
             builder.Entity<Course>().HasOne(c=>c.Category).WithMany(ca=>ca.Courses)
                 .HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Restrict);

             builder.Entity<Order>().HasKey(o=>o.Id);
             builder.Entity<Order>().HasOne(o => o.User)
                 .WithMany(u => u.Orders).HasForeignKey(o=>o.UserId);
             builder.Entity<Order>().HasOne(o => o.Payment).WithOne(p => p.Order)
                 .HasForeignKey<Order>(o => o.PaymentId);

             builder.Entity<StudentCourse>().HasKey(sc => sc.Id);
             builder.Entity<StudentCourse>().HasOne(sc=>sc.Student).WithMany(s=>s.SubscribedCourses).HasForeignKey(s=>s.StudentId).OnDelete(DeleteBehavior.Restrict);
             builder.Entity<StudentCourse>().HasOne(sc => sc.Course).WithMany(c => c.StudentCourses)
                 .HasForeignKey(sc => sc.CourseId).OnDelete(DeleteBehavior.Restrict); 

             builder.Entity<Category>().HasKey(c => c.Id);
             builder.Entity<Category>()
            .HasMany(ca => ca.Courses)
               .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);


            SeedData.Seed(builder);


        }
     }
     
}
