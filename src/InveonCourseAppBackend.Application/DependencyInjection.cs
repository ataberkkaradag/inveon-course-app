using InveonCourseAppBackend.Application.Abstraction.Repositories;
using InveonCourseAppBackend.Application.Abstraction.Services;
using InveonCourseAppBackend.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonCourseAppBackend.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPaymentService, PaymentService>();

        }
    }
}
